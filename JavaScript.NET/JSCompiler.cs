using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace JavaScript.NET
{
    public class JSCompiler
    {
        public static string Compile(List<string> sources)
        {
            string output = "";
            output += "// BEGIN EXTRAS";
            output += Extras + "\n";
            output += "// END EXTRAS \n\n";
            List<string> entryPoints = new List<string>();
            foreach (string source in sources)
            {
                output += CompileSource(source, entryPoints) + "\n\n";
            }

            foreach (string entryPoint in entryPoints)
            {
                output += entryPoint + "\n";
            }

            output += "\n/* COMPILED WITH JavaScript.NET */";
            return output;
        }

        private static string CompileSource(string source, List<string> entryPoints)
        {
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(source);
            CompilationUnitSyntax root = syntaxTree.GetCompilationUnitRoot();
            MemberDeclarationSyntax firstMember = root.Members[0];
            ClassDeclarationSyntax classDeclaration = null;
            if (firstMember.Kind() == SyntaxKind.ClassDeclaration)
            {
                classDeclaration = (ClassDeclarationSyntax) firstMember;
            }
            else if (firstMember.Kind() == SyntaxKind.NamespaceDeclaration)
            {
                var namespaceDeclaration = (NamespaceDeclarationSyntax) firstMember;
                var namespaceFirstMember = namespaceDeclaration.Members[0];
                if (namespaceFirstMember.Kind() == SyntaxKind.ClassDeclaration)
                {
                    classDeclaration = (ClassDeclarationSyntax) namespaceFirstMember;
                }
                else
                {
                    throw new CompilationException("After namespace declaration must come the class declaration!");
                }
            }

            if (classDeclaration == null)
                throw new CompilationException("No class declaration found!");

            return CompileClass(classDeclaration, entryPoints);
        }

        private static string CompileClass(ClassDeclarationSyntax classDeclaration, List<string> entryPoints)
        {
            ReplacerVisitor visitor = new ReplacerVisitor();
            classDeclaration = (ClassDeclarationSyntax) visitor.VisitClassDeclaration(classDeclaration);
            CompilationContext context = new CompilationContext
            {
                Source = "// BEGIN C# Class: " + classDeclaration.Identifier + "\n"
            };
            context.Source += $"class {classDeclaration.Identifier}{CompileExtends(classDeclaration)} {{\n";
            
            foreach (MemberDeclarationSyntax member in classDeclaration.Members)
            {
                if (member.Kind() == SyntaxKind.MethodDeclaration)
                {
                    MethodDeclarationSyntax method = (MethodDeclarationSyntax) member;
                    context.Source += CompileMethod(method, out bool isEntryPoint);
                    if (isEntryPoint)
                    {
                        entryPoints.Add(classDeclaration.Identifier + "." + method.Identifier + "();");
                    }
                }
                else if (member.Kind() == SyntaxKind.FieldDeclaration)
                {
                    FieldDeclarationSyntax field = (FieldDeclarationSyntax) member;
                    context.Source += CompileField(field);
                }
                else if (member.Kind() == SyntaxKind.ConstructorDeclaration)
                {
                    ConstructorDeclarationSyntax constructor = (ConstructorDeclarationSyntax) member;
                    context.Source += CompileConstructor(constructor);
                }
                else if (member.Kind() == SyntaxKind.PropertyDeclaration)
                {
                    PropertyDeclarationSyntax property = (PropertyDeclarationSyntax) member;
                    context.Source += CompileProperty(property);
                }
            }

            context.Source += "}\n";
            return context.Source + "// END C# Class: " + classDeclaration.Identifier + "\n";
        }

        private static string CompileProperty(PropertyDeclarationSyntax property)
        {
            string source = "";
            if (property.AccessorList?.Accessors.Any(accessor =>
                accessor.Kind() == SyntaxKind.GetAccessorDeclaration) ?? false)
            {
                source += "get " + property.Identifier + "() {\n";
                source += "return this." + property.Identifier + ";\n}\n";
            }

            if (property.AccessorList?.Accessors.Any(accessor =>
                accessor.Kind() == SyntaxKind.SetAccessorDeclaration) ?? false)
            {
                source += "set " + property.Identifier + "(val) {\n";
                source += "this." + property.Identifier + " = val;\n}\n";
            }

            return source;
        }

        private static string CompileBlock(BlockSyntax block)
        {
            string source = "";
            foreach (StatementSyntax statement in block.Statements)
            {
                source += (statement + "\n").Replace("==", "===").Replace("!=", "!==");
            }

            return source;
        }

        private static string CompileConstructor(ConstructorDeclarationSyntax constructor)
        {
            string parameters = CompileParameters(constructor.ParameterList.Parameters);
            string source = $"constructor({parameters}) {{\n";
            if (constructor.Body != null)
                source += CompileBlock(constructor.Body);
            return source + "}\n";
        }

        private static string CompileMethod(MethodDeclarationSyntax method, out bool isEntryPoint)
        {
            string source = "";
            string parameters = CompileParameters(method.ParameterList.Parameters);
            bool isStatic = method.DescendantTokens().Any(x => x.Kind() == SyntaxKind.StaticKeyword);
            source += (isStatic ? "static " : "") + $"{method.Identifier}({parameters}) {{\n";
            source += CompileMethodBody(method);
            source += "}\n";
            AttributeSyntax entryPointAttr = GetMethodAttribute(method, "EntryPoint");
            isEntryPoint = entryPointAttr != null;
            return source;
        }

        private static string CompileMethodBody(MethodDeclarationSyntax method)
        {
            AttributeSyntax attribute = GetMethodAttribute(method, "JSFunction");
            if (attribute != null)
            {
                string code = attribute.ArgumentList?.Arguments[0].ToString() ?? "";
                return ReplaceLastOccurrence(ReplaceFirst(code, "\"", ""), "\"", "") + "\n";
            }

            if (method.Body == null)
                return "";
            
            return CompileBlock(method.Body);
        }

        private static AttributeSyntax GetMethodAttribute(MethodDeclarationSyntax method, string name)
        {
            foreach (AttributeListSyntax attributeList in method.AttributeLists)
            {
                AttributeSyntax attribute = attributeList.Attributes.FirstOrDefault(o => o.Name.ToString().Trim() == name.Trim());
                if (attribute != null)
                    return attribute;
            }

            return null;
        }

        private static string CompileParamter(ParameterSyntax parameter)
        {
            string source = parameter.Identifier.Text;
            if (parameter.Default != null)
            {
                source += " = " + parameter.Default.Value;
            }

            return source;
        }

        private static string CompileField(FieldDeclarationSyntax field)
        {
            return $"static {field.Declaration.Variables[0]};\n";
        }

        private static string CompileParameters(SeparatedSyntaxList<ParameterSyntax> list)
        {
            string parameters = "";
            foreach (ParameterSyntax parameter in list)
            {
                if (parameters == "")
                    parameters = CompileParamter(parameter);
                else
                    parameters += ", " + CompileParamter(parameter);
            }

            return parameters;
        }

        private static string CompileExtends(ClassDeclarationSyntax classDeclaration)
        {
            BaseTypeSyntax baseType = classDeclaration.BaseList?.Types.FirstOrDefault();
            if (baseType != null)
            {
                return " extends " + baseType.Type.ToString().Trim();
            }

            return "";
        }

        // https://stackoverflow.com/questions/8809354/replace-first-occurrence-of-pattern-in-a-string
        private static string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search, StringComparison.Ordinal);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        // https://stackoverflow.com/questions/14825949/replace-the-last-occurrence-of-a-word-in-a-string-c-sharp
        private static string ReplaceLastOccurrence(string source, string find, string replace)
        {
            int place = source.LastIndexOf(find, StringComparison.Ordinal);
            if (place == -1)
                return source;

            string result = source.Remove(place, find.Length).Insert(place, replace);
            return result;
        }

        private static readonly string Extras = @"
Array.prototype.remove = function() {
    var what, a = arguments, L = a.length, ax;
    while (L && this.length) {
        what = a[--L];
        while ((ax = this.indexOf(what)) !== -1) {
            this.splice(ax, 1);
        }
    }
    return this;
};";
    }
}
