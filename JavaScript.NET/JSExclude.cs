using System;

namespace JavaScript.NET
{
    /// <summary>
    /// The JS exclude excluded the compiling of specific classes, enums and interfaces.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Class | AttributeTargets.Interface)]
    public class JSExclude : Attribute
    {
    }
}
