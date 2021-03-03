using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class RadiusBlip : Blip
        {
            public extern RadiusBlip(double x, double y, double z, double radius);
        }
    }
}