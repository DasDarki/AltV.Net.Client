using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class Checkpoint : WorldObject
        {
            public CheckpointType checkpointType { get; set; }
            public Vector3 nextPos { get; set; }
            public double radius { get; set; }
            public double height { get; set; }
            public RGBA color { get; set; }

            public extern Checkpoint(CheckpointType type, Vector3 pos, Vector3 nextPos, double radius, double height,
                RGBA rgbcolor);

            public extern bool isEntityIn(Entity entity);
            public extern bool isPointIn(Vector3 pos);
        }
    }
}