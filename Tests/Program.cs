using System;
using System.Collections.Generic;
using JavaScript.NET;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sources = new List<string>
            {
                /*@"
using System;
public class Test
{
    public static int TestNr = 0;

    [JSFunction(""console.log(msg)"")]
    public static extern void ConsoleLog(string msg = ""default val"");

    public static void Test()
    {
        ConsoleLog(""Message"");
    }
}
                 ",*/
                /*@"
public class Person
{
    public string Name { get; set; }

    public bool IsCool { get; }

    public Person(string name)
    {
        Test();
        Name = name;
        IsCool = true;
    }

    public void Dab()
    {
        var test = true ? ""ni"" : ""sss"";
        if(true) {
            if(false) {

            } else if(false) {
            
            } else {

            }
        }
        return ""dab"" + Name;
    }
}
"*/
                @"
public class Test
{
    public static void Main()
    {
        List<string> list = new List<string>();
        list.Add(""item 1"");
        list.Contains(""item 1"");
        list.Remove(""item 1"");

        Dictionary<string, object> map = new Dictionary<string, object>();
        map.Add(""key"", ""asdasd"");
        map.ContainsKey(""key"");
        map.Remove(""key"");
    }
}
"
            };
            Console.WriteLine(JSCompiler.Compile(sources));
            Console.ReadKey();
            Dictionary<string, object> map = new Dictionary<string, object>();
            
        }
    }
}
