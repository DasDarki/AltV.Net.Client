using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class Vector2
        {
            public double x { get; }
            public double y { get; }

            public double length { get; }

            public extern Vector2(double x, double y);
            public extern Vector2(double[] coords);
            public extern Vector2(Vector2 v);

            public extern double[] toArray();
            public extern Vector2 add(double x, double y);
            public extern Vector2 add(double amount);
            public extern Vector2 add(double[] array);
            public extern Vector2 add(Vector2 v);
            public extern Vector2 sub(double x, double y);
            public extern Vector2 sub(double amount);
            public extern Vector2 sub(double[] array);
            public extern Vector2 sub(Vector2 v);
            public extern Vector2 div(double x, double y);
            public extern Vector2 div(double amount);
            public extern Vector2 div(double[] array);
            public extern Vector2 div(Vector2 v);
            public extern Vector2 mul(double x, double y);
            public extern Vector2 mul(double amount);
            public extern Vector2 mul(double[] array);
            public extern Vector2 mul(Vector2 v);
            public extern Vector2 negative();
            public extern Vector2 normalize();
            public extern double distanceTo(Vector2 v);
            public extern Vector2 angleTo(Vector2 v);
            public extern Vector2 angleToDegrees(Vector2 v);
            public extern Vector2 toRadians();
            public extern Vector2 toDegrees();
            public extern bool isInRange(Vector2 v, double range);
        }
    }
}