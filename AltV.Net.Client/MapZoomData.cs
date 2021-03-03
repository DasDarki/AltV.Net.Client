using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class MapZoomData
        {
            public double fZoomScale { get; set; }
            public double fZoomSpeed { get; set; }
            public double fScrollSpeed { get; set; }
            public double vTilesX { get; set; }
            public double vTilesY { get; set; }

            public extern MapZoomData(double zoomDataId);

            public extern void reset();
            public static extern void resetAll();
            public static extern MapZoomData get(string zoomData);
        }
    }
}