# AltV.Net.Client
AltV.Net.Client is a work-around for the AltV JS Client-Side API which uses a custom written C# to JS Compiler.

## JavaScript.NET
JavaScript.NET is the custom written C# to JS compiler which is used by AltV.Net.Client. It uses Roslyn to analyze the C# Code and transform it slowly into JavaScript. Its in a really early state and might have some bugs but it currently supports a lot of things.
- Class Generator
- Static Fields
- Static Methods
- Class Methods and Properties
- Lists
- Dictionaries
- JS Injection

Here an example:
```csharp
using System.Collections.Generic;
using JavaScript.NET;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> csharpSources = new List<string>();
            string jsCode = JSCompiler.Compile(csharpSources);
        }
    }
}

```

## Limitations
The following list contains all limitations which are currently existing and known:
- Interfaces
- Enum
- One Class per File
- Subclasses are not allowed