using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public interface IDiscordUser
        {
            public string id { get; }
            public string name { get; }
            public string discriminator { get; }
            public string avatar { get; }
        }
    }
}