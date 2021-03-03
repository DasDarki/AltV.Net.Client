# AltV.Net.Client
AltV.Net.Client is a work-around for the AltV JS Client-Side API which uses a custom written C# to JS Compiler.

## Disclaimer
This is kinda an experiment. We do not know if this works or not. There are some limitations like specific JS features and C# features you cannot use. Please keep in mind
this could be used in production but you need to test it yourself if it fits to your needs.    
One thing you need to keep an eye on: The classes are created in a way you would use them in JS. Please do not destroy this because than your written code probably won't work,
e.g. every API class reference needs to begin with alt.*.

## JavaScript.NET
JavaScript.NET is the custom written C# to JS compiler which is used by AltV.Net.Client. It uses Roslyn to analyze the C# Code and transform it slowly into JavaScript. Its in a really early state and might have some bugs but it currently supports a lot of things.
- Class Generator
- Static Fields
- Static Methods
- Class Methods and Properties
- Lists
- Dictionaries
- Interfaces
- Enums
- Events
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
- Nested Classes