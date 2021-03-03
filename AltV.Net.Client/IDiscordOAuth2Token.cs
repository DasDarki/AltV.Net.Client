using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public interface IDiscordOAuth2Token
        {
            public string token { get; }
            public long expires { get; }
            public string scopes { get; }
        }
    }
}