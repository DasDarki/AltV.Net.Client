using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class MemoryBuffer
        {
            public extern MemoryBuffer(double size);
            
            public extern byte @byte(double offset);
            
            public extern double @double(double offset);
            
            public extern float @float(double offset);
            
            public extern int @int(double offset);
            
            public extern long @long(double offset);
            
            public extern short @short(double offset);
            
            public extern string @string(double offset, double length);
            
            public extern ushort ubyte(double offset);
            
            public extern uint @uint(double offset);
            
            public extern ulong @ulong(double offset);
            
            public extern ushort @ushort(double offset);
            
            public extern long address(double offset);
            
            public extern bool free();
        }
    }
}