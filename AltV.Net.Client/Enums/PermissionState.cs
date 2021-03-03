using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public enum PermissionState
        {
            Allowed,
            Denied,
            Unspecified,
            Failed
        }
    }
}
