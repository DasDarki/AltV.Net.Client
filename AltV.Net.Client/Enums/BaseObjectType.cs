using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public enum BaseObjectType
        {
            Player,
            Vehicle,
            Blip,
            WebView,
            VoiceChannel,
            Colshape,
            Checkpoint
        }
    }
}
