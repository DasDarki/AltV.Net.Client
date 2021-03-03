using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class File
        {
            /// <summary>
            /// Determines whether file exists with the specified filename.
            /// </summary>
            /// <param name="filename">The name of the file.</param>
            /// <returns>Return is dependent on whether file with the specified filename exists.</returns>
            public static extern bool exists(string filename);

            /// <summary>
            /// Reads content of the file.
            /// </summary>
            /// <param name="filename">The name of the file.</param>
            /// <param name="encoding">The encoding of the file. If not specified, it defaults to "utf-8".</param>
            public static extern string read(string filename, FileEncoding encoding = FileEncoding.Utf8);
        }
    }
}