using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AltV.Net.Client.Compiler
{
    internal class Config
    {
        /// <summary>
        /// The path to the ouput directory.
        /// </summary>
        public string Out { get; set; }

        /// <summary>
        /// The path to the source directory.
        /// </summary>
        public string Src { get; set; }

        /// <summary>
        /// A list containing directories or specific files which are defined as assets.
        /// The assets will be copied relative to the resource directory.
        /// </summary>
        public Dictionary<string, string> Assets { get; set; } = new Dictionary<string, string>();

        public void Normalize()
        {
            string rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
            Out = Out.Replace("~", rootPath);
            Src = Src.Replace("~", rootPath);
            Dictionary<string, string> normalizedAssets = new Dictionary<string, string>();
            foreach (string key in Assets.Keys)
            {
                string value = Assets[key];
                normalizedAssets.Add(key.Replace("~", rootPath), value.Replace("~", rootPath));
            }

            Assets = normalizedAssets;
        }
    }
}
