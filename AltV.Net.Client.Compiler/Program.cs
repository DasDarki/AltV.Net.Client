using System;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace AltV.Net.Client.Compiler
{
    class Program
    {
        private static readonly Deserializer Deserializer =
            new DeserializerBuilder().WithNamingConvention(new UnderscoredNamingConvention()).Build();

        public static void Main(string[] args)
        {
            Console.Title = "AltV.Net.Client Compiler (c) 2020 github.com/EternityLife-de";
            string configPath;
            if (args.Length >= 1)
            {
                configPath = args[0];
            }
            else
            {
                Console.Write("Enter Path to Compiler Config: ");
                configPath = Console.ReadLine();
            }

            Config config = LoadConfig(configPath);
            if (config == null) return;
            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("     !!!PRESS ENTER TO RECOMPILE!!!");
                Console.ReadLine();
                Exception exception = AltCompiler.Compile(config);
                if (exception != null)
                {
                    PrintError("An error occurred while compiling! " + exception);
                }
            }
        }

        private static Config LoadConfig(string path)
        {
            try
            {
                Config config = Deserializer.Deserialize<Config>(File.ReadAllText(path));
                if (string.IsNullOrEmpty(config.Out))
                    throw new NullReferenceException("The out path cannot be null!");
                if (string.IsNullOrEmpty(config.Src))
                    throw new NullReferenceException("The src path cannot be null!");
                return config;
            }
            catch (Exception e)
            {
                PrintError("An error occurred while parsing config at " + path + "! " + e);
                return null;
            }
        }

        private static void PrintError(string msg)
        {
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}
