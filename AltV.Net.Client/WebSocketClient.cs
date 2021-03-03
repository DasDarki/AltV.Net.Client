using System.Diagnostics.CodeAnalysis;
using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        /// <remarks>alpha</remarks>
        [JSExclude]
        [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
        public class WebSocketClient : BaseObject
        {
            public bool autoReconnect { get; set; }
            
            public bool perMessageDeflate { get; set; }
            
            public double pingInterval { get; set; }
            
            public string url { get; set; }
            
            public WebSocketReadyState readyState { get; }

            public extern WebSocketClient(string url);

            public extern void on(string eventName, JSCompiler.JSCallback callback);
            
            public extern void off(string eventName, JSCompiler.JSCallback callback);

            /// <summary>
            /// Starts the websocket connection.
            /// </summary>
            public extern void start();

            /// <summary>
            /// Stops the websocket connection.
            /// </summary>
            public extern void stop();

            /// <summary>
            /// Sends the specified message to the websocket server.
            /// </summary>
            /// <param name="message">The message to send.</param>
            /// <returns>Whether sending the message was successful.</returns>
            public extern bool send(string message);

            /// <summary>
            /// Adds a sub protocol to the websocket.
            /// </summary>
            /// <param name="protocol">Name of the protocol.</param>
            public extern void addSubProtocol(string protocol);

            /// <summary>
            /// Gets all added sub protocols.
            /// </summary>
            public extern string[] getSubProtocols();

            /// <summary>
            /// Sets the specified header to the specified value.
            /// </summary>
            /// <param name="header">Header name.</param>
            /// <param name="value">Header value.</param>
            public extern void setExtraHeader(string header, string value);
            
            [JSExclude]
            public class Events
            {
                public const string Open = "open";
                public const string Close = "close";
                public const string Message = "message";
                public const string Error = "error";
            }
        }
    }
}