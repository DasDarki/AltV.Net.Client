using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class WebView : BaseObject
        {
            /// <summary>
            /// The visibility state of the web view.
            /// </summary>
            public bool isVisible { get; set; }

            /// <summary>
            /// The url to the website of the web view.
            /// </summary>
            public string url { get; set; }

            /// <summary>
            /// Creates a fullscreen web view.
            /// </summary>
            /// <param name="url">URL of the html file.</param>
            /// <param name="isOverlay">true to render as overlay, false to render on game's GUI stage.</param>
            public extern WebView(string url, bool isOverlay = false);

            /// <summary>
            /// Creates a web view.
            /// </summary>
            /// <param name="url">URL of the html file.</param>
            /// <param name="pos">x, y coordinates of the position.</param>
            public extern WebView(string url, Vector2 pos);

            /// <summary>
            /// Creates a custom size WebView and specific pos.
            /// </summary>
            /// <param name="url">URL of the html file.</param>
            /// <param name="pos">x, y coordinates of the position.</param>
            /// <param name="size">x, y to define the size.</param>
            public extern WebView(string url, Vector2 pos, Vector2 size);

            /// <summary>
            /// Creates a custom size WebView and specific pos.
            /// </summary>
            /// <param name="url">URL of the html file.</param>
            /// <param name="isOverlay">true to render as overlay, false to render on game's GUI stage.</param>
            /// <param name="pos">x, y coordinates of the position.</param>
            /// <param name="size">x, y to define the size.</param>
            public extern WebView(string url, bool isOverlay, Vector2 pos, Vector2 size);

            /// <summary>
            /// Creates a WebView rendered on game object.
            /// </summary>
            /// <param name="url">URL of the html file.</param>
            /// <param name="propHash">Hash of object to render on.</param>
            /// <param name="targetTexture">Name of object's texture to replace.</param>
            public extern WebView(string url, double propHash, string targetTexture);

            /// <summary>
            /// Emits specified event across particular WebView.
            /// </summary>
            /// <param name="eventName">Name of the event.</param>
            /// <param name="args">Rest parameters for emit to send.</param>
            public extern void emit(string eventName, params object[] args);

            /// <summary>
            /// Unsubscribes from WebView event handler with specified listener.
            /// </summary>
            /// <param name="eventName">Name of the event.</param>
            /// <param name="listener">Listener that should be removed.</param>
            /// <remarks>Listener should be of the same reference as when event was subscribed.</remarks>
            public extern void off(string eventName, JSCompiler.JSCallback listener);

            /// <summary>
            /// Subscribes to WebView event handler with specified listener.
            /// </summary>
            /// <param name="eventName">Name of the event.</param>
            /// <param name="listener">Listener that should be added.</param>
            public extern void on(string eventName, JSCompiler.JSCallback listener);

            /// <summary>
            /// Focuses the webview so it can be interacted with.
            /// </summary>
            public extern void focus();

            /// <summary>
            /// Unfocuses the webview so it ignores user input.
            /// </summary>
            public extern void unfocus();
        }
    }
}