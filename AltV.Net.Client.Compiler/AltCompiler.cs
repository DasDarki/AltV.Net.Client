using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using JavaScript.NET;

namespace AltV.Net.Client.Compiler
{
    internal static class AltCompiler
    {
        public static Exception Compile(Config config)
        {
            try
            {
                config.Normalize();
                Directory.CreateDirectory(config.Out);
                string src = Path.Combine(config.Out, "src");
                Directory.CreateDirectory(src);
                List<string> sources = new List<string>();
                CollectSources(config.Src, sources);
                string jsSource = JSCompiler.Compile(sources);
                StringBuilder finalSource = new StringBuilder();
                finalSource.Append("import * as native from 'natives';\n");
                finalSource.Append("import * as alt from 'alt';\n\n");

                finalSource.Append(jsSource);
                File.WriteAllText(Path.Combine(src, "main.mjs"), finalSource.ToString());
                CopyAssets(config, config.Out);
                File.WriteAllText(Path.Combine(config.Out, "resource.cfg"),
                    ResourceCfg.Replace("%files%", string.Join(", ", CollectDirs(config.Out))));
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        private static List<string> CollectDirs(string path)
        {
            List<string> dirs = new List<string>();
            foreach (string dir in Directory.GetDirectories(path))
            {
                dirs.Add(new DirectoryInfo(dir).Name + "/*");
            }

            return dirs;
        }

        private static void CollectSources(string dir, List<string> sources)
        {
            foreach (string file in Directory.GetFiles(dir))
            {
                if (!Path.GetExtension(file).ToLower().EndsWith("cs")) continue;
                sources.Add(File.ReadAllText(file));
            }

            foreach (string otherDir in Directory.GetDirectories(dir))
            {
                CollectSources(otherDir, sources);
            }
        }

        private static void CopyAssets(Config config, string outPath)
        {
            foreach (string path in config.Assets.Keys)
            {
                string destPath = path.Replace(config.Assets[path], outPath);
                if (IsDirectory(path))
                {
                    foreach (string dirPath in Directory.GetDirectories(path, "*",
                        SearchOption.AllDirectories))
                        Directory.CreateDirectory(dirPath.Replace(path, destPath));

                    foreach (string newPath in Directory.GetFiles(path, "*.*",
                        SearchOption.AllDirectories))
                        File.Copy(newPath, newPath.Replace(path, destPath), true);
                }
                else
                {
                    File.Copy(path, destPath, true);
                }
            }
        }

        private static bool IsDirectory(string path)
        {
            FileAttributes attr = File.GetAttributes(path);
            return attr.HasFlag(FileAttributes.Directory);
        }

        private static readonly string ResourceCfg = "type: js\n" + "client-main: src/main.mjs\n" + "client-files: [%files%]";
    }
}
