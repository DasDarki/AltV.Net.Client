using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class RGBA
        {
            public double r { get; set; }
            public double g { get; set; }
            public double b { get; set; }
            public double a { get; set; }

            public extern RGBA(double r, double g, double b, double a);
        }
    }
}