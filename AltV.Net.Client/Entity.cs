using System.Collections.Generic;
using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class Entity : WorldObject
        {
            /// <summary>
            /// A list containing all entities in the world.
            /// </summary>
            public static readonly List<Entity> all;

            /// <summary>
            /// The unique entity id.
            /// </summary>
            public double id { get; }

            /// <summary>
            /// The internal game id that can be used in native calls.
            /// </summary>
            public double scriptID { get; }

            /// <summary>
            /// The hash of the entity model.
            /// </summary>
            public double model { get; }

            /// <summary>
            /// The entity position.
            /// </summary>
            public override Vector3 pos => _pos;

            private readonly Vector3 _pos;

            /// <summary>
            /// The entity rotation.
            /// </summary>
            public Vector3 rot { get; }

            /// <summary>
            /// Whether the entity is visible or not.
            /// </summary>
            public bool visible { get; }

            /// <summary>
            /// Gets a value using the specified key.
            /// </summary>
            /// <param name="key">The key of the value to get.</param>
            /// <returns>Dynamic value associated with the specified key.</returns>
            public extern object getSyncedMeta(string key);

            /// <summary>
            /// Determines whether contains the specified key.
            /// </summary>
            /// <param name="key">The key of the value to locate.</param>
            /// <returns>Return is dependent on whether element associated with the specified key is stored.</returns>
            public extern bool hasSyncedMeta(string key);

            /// <summary>
            /// Gets a value using the specified key.
            /// </summary>
            /// <param name="key">The key of the value to get.</param>
            /// <returns>Dynamic value associated with the specified key.</returns>
            public extern object getStreamSyncedMeta(string key);

            /// <summary>
            /// Determines whether contains the specified key.
            /// </summary>
            /// <param name="key">The key of the value to locate.</param>
            /// <returns>Return is dependent on whether element associated with the specified key is stored.</returns>
            public extern bool hasStreamSyncedMeta(string key);

            /// <summary>
            /// Retrieves the entity from the pool.
            /// </summary>
            /// <param name="id">The id of the entity.</param>
            /// <returns>Entity if it was found, otherwise null.</returns>
            public static extern Entity getByID(double id);

            /// <summary>
            /// Retrieves the entity from the pool.
            /// </summary>
            /// <param name="scriptID">The script id of the entity.</param>
            /// <returns>Entity if it was found, otherwise null.</returns>
            public static extern Entity getByScriptID(double scriptID);
        }
    }
}