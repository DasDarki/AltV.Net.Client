using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class PointBlip : Blip
        {
            public extern PointBlip(double x, double y, double z);
        }
    }
}