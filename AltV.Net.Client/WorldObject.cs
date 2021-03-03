using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class WorldObject : BaseObject
        {
            /// <summary>
            /// The object position.
            /// </summary>
            public virtual Vector3 pos { get; set; }
        }
    }
}