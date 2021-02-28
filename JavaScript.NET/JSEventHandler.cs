using System;

namespace JavaScript.NET
{
    [AttributeUsage(AttributeTargets.Event)]
    public class JSEventHandler : JSFunction
    {
        public JSEventHandler(string code) : base(code)
        {
        }
    }
}
