using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public enum Permission
        {
            None,
            ScreenCapture,
            WebRTC,
            All
        }
    }
}
