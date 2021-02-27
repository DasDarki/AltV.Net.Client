using System;

namespace JavaScript.NET
{
    [AttributeUsage(AttributeTargets.Method)]
    public class JSFunction : Attribute
    {
        public string Code { get; }

        public JSFunction(string code)
        {
            Code = code;
        }
    }
}
