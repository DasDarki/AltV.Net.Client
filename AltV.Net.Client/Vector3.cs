using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class Vector3
        {
            public double x { get; }
            public double y { get; }
            public double z { get; }

            public double length { get; }

            public extern Vector3(double x, double y, double z);
            public extern Vector3(double[] coords);
            public extern Vector3(Vector3 v);

            public extern double[] toArray();
            public extern Vector3 add(double x, double y);
            public extern Vector3 add(double amount);
            public extern Vector3 add(double[] array);
            public extern Vector3 add(Vector3 v);
            public extern Vector3 sub(double x, double y);
            public extern Vector3 sub(double amount);
            public extern Vector3 sub(double[] array);
            public extern Vector3 sub(Vector3 v);
            public extern Vector3 div(double x, double y);
            public extern Vector3 div(double amount);
            public extern Vector3 div(double[] array);
            public extern Vector3 div(Vector3 v);
            public extern Vector3 mul(double x, double y);
            public extern Vector3 mul(double amount);
            public extern Vector3 mul(double[] array);
            public extern Vector3 mul(Vector3 v);
            public extern Vector3 negative();
            public extern Vector3 normalize();
            public extern double distanceTo(Vector3 v);
            public extern Vector3 angleTo(Vector3 v);
            public extern Vector3 angleToDegrees(Vector3 v);
            public extern Vector3 toRadians();
            public extern Vector3 toDegrees();
            public extern bool isInRange(Vector3 v, double range);
        }
    }
}