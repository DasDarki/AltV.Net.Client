using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class Voice
        {
            public static bool muteInput { get; set; }
            
            public static bool activityInputEnabled { get; set; }
            
            public static double activationKey { get; set; }
        }
    }
}