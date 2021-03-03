using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class Blip : WorldObject
        {
            public static RGBA routeColor;

            public double alpha { get; set; }
            public bool asMissionCreator { get; set; }
            public bool bright { get; set; }
            public double category { get; set; }
            public double color { get; set; }
            public bool crewIndicatorVisible { get; set; }
            public double display { get; set; }
            public bool flashes { get; set; }
            public bool flashesAlternate { get; set; }
            public double flashInterval { get; set; }
            public double flashTimer { get; set; }
            public bool friendIndicatorVisible { get; set; }
            public string gxtName { get; set; }
            public double heading { get; set; }
            public bool headingIndicatorVisible { get; set; }
            public bool highDetail { get; set; }
            public string name { get; set; }
            public double number { get; set; }
            public bool outlineIndicatorVisible { get; set; }
            public double priority { get; set; }
            public bool pulse { get; set; }
            public bool route { get; set; }
            public double scale { get; set; }
            public double secondaryColor { get; set; }
            public bool shortRange { get; set; }
            public bool showCone { get; set; }
            public bool shrinked { get; set; }
            public Vector2 size { get; set; }
            public double sprite { get; set; }
            public bool tickVisible { get; set; }

            public extern void fade(double opacity, double duration);
        }
    }
}