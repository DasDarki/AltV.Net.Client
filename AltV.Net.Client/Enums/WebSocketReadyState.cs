using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public enum WebSocketReadyState
        {
            Connecting,
            Open,
            Closing,
            Closed
        }
    }
}