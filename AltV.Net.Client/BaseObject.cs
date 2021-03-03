using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class BaseObject
        {
            /// <summary>
            /// Type of the object.
            /// </summary>
            public readonly BaseObjectType type;

            /// <summary>
            /// Object usability (false, if the object is no longer usable).
            /// </summary>
            public readonly bool valid;

            /// <summary>
            /// Removes the object from the world.
            /// </summary>
            public extern void destroy();

            /// <summary>
            /// Removes the specified key.
            /// </summary>
            /// <param name="key">The key of the value to remove</param>
            public extern void deleteMeta(string key);

            /// <summary>
            /// Gets a value using the specified key.
            /// </summary>
            /// <param name="key">The key of the value to get.</param>
            /// <returns>Dynamic value associated with the specified key.</returns>
            public extern object getMeta(string key);

            /// <summary>
            /// Determines whether contains the specified key.
            /// </summary>
            /// <param name="key">The key of the value to locate.</param>
            /// <returns>True when element associated with the specified key is stored.</returns>
            public extern bool hasMeta(string key);

            /// <summary>
            /// Stores the given value with the specified key.
            /// </summary>
            /// <param name="key">The key of the value to store.</param>
            /// <param name="val">The value.</param>
            /// <remarks>The given value will be shared locally.</remarks>
            public extern void setMeta(string key, object val);
        }
    }
}