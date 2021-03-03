using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public interface IVehicleNeon
        {
            public bool left { get; set; }
            public bool right { get; set; }
            public bool front { get; set; }
            public bool back { get; set; }
        }
    }
}