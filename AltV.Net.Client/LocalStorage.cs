using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class LocalStorage
        {
            /// <summary>
            /// Gets the local storage instance.
            /// </summary>
            public static extern LocalStorage get();
            
            /// <summary>
            /// Deletes the specified key from the local storage.
            /// </summary>
            public extern void delete(string key);

            /// <summary>
            /// Deletes all keys from the local storage.
            /// </summary>
            public extern void deleteAll();
            
            /// <remarks>Alias for deleteAll.</remarks>
            public extern void clear();

            /// <summary>
            /// Gets the value from the specified key in the local storage.
            /// </summary>
            public extern object get(string key);

            /// <summary>
            /// Saves the changes to the disk.
            /// </summary>
            public extern void save();

            /// <summary>
            /// Sets the specified key to the specified value in the local storage.
            /// </summary>
            public extern void set(string key, object value);
            
            private extern LocalStorage();
        }
    }
}