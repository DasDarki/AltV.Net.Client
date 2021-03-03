using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class AreaBlip : Blip
        {
            public extern AreaBlip(double x, double y, double z, double width, double height);
        }
    }
}