using System;

namespace JavaScript.NET
{
    public class Promise<T>
    {
        public delegate void ResolveAndReject(Action<T> resolve, Action<object> reject);
        public delegate void Resolve(Action<T> resolve);
        
        public extern Promise(ResolveAndReject callback);
        public extern Promise(Resolve callback);
        
        public extern Promise<T> then(Action<T> callback);

        public extern Promise<T> @catch(Action<object> errorCallback);
    }
}