using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace JavaScript.NET
{
    internal class ReplacerVisitor : CSharpSyntaxRewriter
    {
        private readonly List<string> _variables = new List<string>();
        private readonly List<string> _methods = new List<string>();
        private readonly List<string> _lists = new List<string>();
        private readonly List<string> _maps = new List<string>();
        private readonly Dictionary<string, string> _events = new Dictionary<string, string>();
        private bool _onlyGathering = true;

        public override SyntaxNode? VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            _onlyGathering = true;
            base.VisitClassDeclaration(node);
            _onlyGathering = false;
            return base.VisitClassDeclaration(node);
        }

        public override SyntaxNode? VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            if(_onlyGathering && !_variables.Contains(node.Identifier.Text))
                _variables.Add(node.Identifier.Text);
            return base.VisitPropertyDeclaration(node);
        }

        public override SyntaxNode? VisitEventFieldDeclaration(EventFieldDeclarationSyntax node)
        {
            if (_onlyGathering)
            {
                string name = node.Declaration.Variables[0].Identifier.ToString();
                if (!_events.ContainsKey(name))
                {
                    foreach (AttributeListSyntax attributeList in node.AttributeLists)
                    {
                        AttributeSyntax attribute = attributeList.Attributes.FirstOrDefault(o => o.Name.ToString().Trim() == "JSEventHandler");
                        if (attribute != null)
                        {
                            string code = attribute.ArgumentList?.Arguments[0].ToString() ?? "";
                            code = JSCompiler.ReplaceFirst(JSCompiler.ReplaceLastOccurrence(code, "\"", ""), "\"", "");
                            _events.Add(name, code);
                        }
                    }
                }
            }

            return base.VisitEventFieldDeclaration(node);
        }

        public override SyntaxNode? VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            if (_onlyGathering && !_methods.Contains(node.Identifier.Text))
            {
                _methods.Add(node.Identifier.Text);
            }
            return base.VisitMethodDeclaration(node);
        }

        public override SyntaxNode? VisitExpressionStatement(ExpressionStatementSyntax node)
        {
            if (!_onlyGathering)
            {
                if (node.Expression is AssignmentExpressionSyntax assignment)
                {
                    string name = assignment.Left.ToString();
                    if (_events.ContainsKey(name))
                    {
                        if (assignment.Right is IdentifierNameSyntax identifier)
                        {
                            if (_methods.Contains(identifier.ToString()))
                            {
                                return SyntaxFactory.ExpressionStatement(
                                    SyntaxFactory.IdentifierName(_events[name].Replace("$cb", "this." + identifier)));
                            }
                        }
                        else
                        {
                            return SyntaxFactory.ExpressionStatement(
                                SyntaxFactory.IdentifierName(_events[name].Replace("$cb", assignment.Right.ToString())));
                        }
                    }
                }
            }

            return base.VisitExpressionStatement(node);
        }

        public override SyntaxNode? VisitIdentifierName(IdentifierNameSyntax node)
        {
            if (!_onlyGathering)
            {
                string name = node.ToString();
                if (_variables.Contains(name) || _methods.Contains(name))
                    name = "this." + name;
                node = node.WithIdentifier(SyntaxFactory.Identifier(name + " "));
            }

            return base.VisitIdentifierName(node);
        }

        public override SyntaxNode? VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            if (node.Type is IdentifierNameSyntax identifier)
            {
                node = node.WithType(identifier.WithIdentifier(SyntaxFactory.Identifier("var")));
            }
            else if (node.Type is GenericNameSyntax)
            {
                node = node.WithType(SyntaxFactory.IdentifierName("var"));
            }

            return base.VisitVariableDeclaration(node);
        }

        public override SyntaxNode? VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            if (node.Expression is MemberAccessExpressionSyntax access)
            {
                if (access.Expression is IdentifierNameSyntax identifier)
                {
                    if (_maps.Contains(identifier.Identifier.ToString()))
                    {
                        if (access.Name.ToString() == "Add")
                        {
                            ArgumentSyntax key = node.ArgumentList.Arguments[0];
                            ArgumentSyntax value = node.ArgumentList.Arguments[1];
                            return SyntaxFactory.IdentifierName(identifier.Identifier + $"[{key}] = {value}");
                        }

                        if (access.Name.ToString() == "Remove")
                        {
                            ArgumentSyntax key = node.ArgumentList.Arguments[0];
                            return SyntaxFactory.IdentifierName($"delete [{key}]");
                        }
                    }
                }
            }

            return base.VisitInvocationExpression(node);
        }

        public override SyntaxNode? VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            if (node.Expression is IdentifierNameSyntax identifier)
            {
                if (_lists.Contains(identifier.Identifier.ToString()))
                {
                    if (node.Name.ToString() == "Add")
                    {
                        node = node.WithName(node.Name.WithIdentifier(SyntaxFactory.Identifier("push")));
                    }
                    else if (node.Name.ToString() == "Contains")
                    {
                        node = node.WithName(node.Name.WithIdentifier(SyntaxFactory.Identifier("includes")));
                    }
                    else if (node.Name.ToString() == "Remove")
                    {
                        node = node.WithName(node.Name.WithIdentifier(SyntaxFactory.Identifier("remove")));
                    }
                }
                else if (_maps.Contains(identifier.Identifier.ToString()))
                {
                    if (node.Name.ToString() == "ContainsKey")
                    {
                        node = node.WithName(node.Name.WithIdentifier(SyntaxFactory.Identifier("hasOwnProperty")));
                    }
                }
            }

            return base.VisitMemberAccessExpression(node);
        }

        public override SyntaxNode? VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            if (node.Type is GenericNameSyntax generic)
            {
                if (generic.Identifier.ToString() == "List")
                {
                    VariableDeclaratorSyntax declarator = node.Parent?.Parent as VariableDeclaratorSyntax;
                    if (!_lists.Contains(declarator.Identifier.ToString()))
                        _lists.Add(declarator.Identifier.ToString());
                    return SyntaxFactory.IdentifierName("[]");
                }
                
                if (generic.Identifier.ToString() == "Dictionary")
                {
                    VariableDeclaratorSyntax declarator = node.Parent?.Parent as VariableDeclaratorSyntax;
                    if (!_maps.Contains(declarator.Identifier.ToString()))
                        _maps.Add(declarator.Identifier.ToString());
                    return SyntaxFactory.IdentifierName("{}");
                }
            }

            return base.VisitObjectCreationExpression(node);
        }
    }
}
