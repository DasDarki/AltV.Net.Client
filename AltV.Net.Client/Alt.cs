using System;
using JavaScript.NET;

namespace AltV.Net.Client
{
    /// <summary>
    /// The main entry point class for accessing the client altV api.
    /// </summary>
    [JSExclude]
    public partial class alt
    {
        /// <summary>
        /// Returns the name of the current running resource from where this method got called.
        /// </summary>
        public static readonly string resourceName;
        
        /// <summary>
        /// Returns the version of the client.
        /// </summary>
        /// <remarks>It's a slightly modified semantic versioning specification, which can be matched using this regular expression pattern `^(0|[1-9]\d*)\.(0|[1-9]\d*)(?:-((?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))$`.</remarks>
        public static readonly string version;
        
        /// <summary>
        /// Returns the version of the client SDK.
        /// </summary>
        /// <remarks>It's the version of the SDK the current runtime was compiled with.</remarks>
        public static readonly string sdkVersion;
        
        /// <summary>
        /// Returns the current client branch.
        /// </summary>
        public static readonly string branch;

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key of the value to remove.</param>
        public static extern void deleteMeta(string key);

        /// <summary>
        /// Gets a value using the specified key
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>Dynamic value associated with the specified key.</returns>
        public static extern object getMeta(string key);

        /// <summary>
        /// Stores the given value with the specified key.
        /// </summary>
        /// <param name="key">he key of the value to store.</param>
        /// <param name="val">The value</param>
        /// <remarks>The given value will be shared locally to all resources.</remarks>
        public static extern void setMeta(string key, object val);
        
        /// <summary>
        /// Gets a value using the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>Dynamic value associated with the specified key.</returns>
        public static extern object getSyncedMeta(string key);

        /// <summary>
        /// Determines whether contains the specified key.
        /// </summary>
        /// <param name="key">The key of the value to locate.</param>
        /// <returns>Return is dependent on whether element associated with the specified key is stored.</returns>
        public static extern bool hasSyncedMeta(string key);

        /// <summary>
        /// Adds a new gxt text with the specified value.
        /// </summary>
        /// <param name="key">Gxt text name.</param>
        /// <param name="val">Gxt text value.</param>
        public static extern void addGxtText(string key, string val);

        /// <summary>
        /// Executes the specified scaleform method on the minimap.
        /// </summary>
        public static extern bool beginScaleformMovieMethodMinimap(string methodName);

        /// <summary>
        /// Clears a timer set with the <see cref="everyTick"/> function.
        /// </summary>
        /// <param name="id">The id of a timer.</param>
        public static extern void clearEveryTick(double id);

        /// <summary>
        /// Clears a timer set with the <see cref="setInterval"/> function.
        /// </summary>
        /// <param name="id">The id of a timer.</param>
        public static extern void clearInterval(double id);

        /// <summary>
        /// Clears a timer set with the <see cref="nextTick"/> function.
        /// </summary>
        /// <param name="id">The id of a timer.</param>
        public static extern void clearNextTick(double id);

        /// <summary>
        /// Clears a timer set with the <see cref="setTimeout"/> function.
        /// </summary>
        /// <param name="id">The id of a timer.</param>
        public static extern void clearTimeout(double id);

        /// <summary>
        /// hidden
        /// </summary>
        public static extern void clearTimer(double id);

        /// <summary>
        /// Emits specified event across client resources.
        /// </summary>
        /// <param name="name">Name of the event.</param>
        /// <param name="args">Rest parameters for emit to send.</param>
        public static extern void emit(string name, params object[] args);

        /// <summary>
        /// Emits specified event to server
        /// </summary>
        /// <param name="name">Name of the event.</param>
        /// <param name="args">Rest parameters for emit to send.</param>
        public static extern void emitServer(string name, params object[] args);

        /// <summary>
        /// Schedules execution of handler on every frame.
        /// </summary>
        /// <param name="handler">Handler that should be scheduled for execution.</param>
        /// <returns>A number representing the id value of the timer that is set. Use this value with the <see cref="clearEveryTick"/> function to cancel the timer.</returns>
        public static extern double everyTick(Action handler);

        /// <summary>
        /// Returns whether the game controls are currently enabled.
        /// </summary>
        public static extern bool gameControlsEnabled();

        /// <summary>
        /// Gets the current position of the cursor.
        /// </summary>
        public static extern Vector2 getCursorPos();

        /// <summary>
        /// Gets the value of the specified gxt text
        /// </summary>
        /// <param name="key">Gxt text name.</param>
        public static extern string getGxtText(string key);

        public static extern string getLicenseHash();

        /// <summary>
        /// Gets the current alt:V locale.
        /// </summary>
        public static extern string getLocale();

        /// <summary>
        /// Gets the current milliseconds per game minute.
        /// </summary>
        /// <remarks>This is set with the <see cref="setMsPerGameMinute"/> function.</remarks>
        public static extern double getMsPerGameMinute();

        /// <summary>
        /// Gets the state of the specified permission.
        /// </summary>
        /// <param name="permId">Permission id.</param>
        /// <returns>Permission state.</returns>
        public static extern PermissionState getPermissionState(Permission permId);

        /// <summary>
        /// Gets a value of the specified statistic.
        /// </summary>
        /// <param name="statName">Name of the statistic.</param>
        public static extern double getState(StatName statName);

        /// <summary>
        /// Creates a hash using Jenkins one-at-a-time algorithm.
        /// </summary>
        /// <param name="str">A string from which hash will be created.</param>
        public static extern double hash(string str);

        /// <summary>
        /// Returns state of console window.
        /// </summary>
        /// <returns>True when console window is opened.</returns>
        public static extern bool isConsoleOpen();

        /// <summary>
        /// Returns state of game window.
        /// </summary>
        /// <returns>True when game window is focused.</returns>
        public static extern bool isGameFocused();

        /// <summary>
        /// Returns if alt:V is in streamer mode.
        /// </summary>
        /// <returns>True when alt:V client is launched in streamer mode.</returns>
        public static extern bool isInStreamerMode();

        /// <summary>
        /// Returns if alt:V is in debug mode.
        /// </summary>
        /// <returns>True when alt:V client is launched with debug mode enabled.</returns>
        public static extern bool isInDebug();

        /// <summary>
        /// Returns whether voice activity input is enabled in alt:V settings.
        /// </summary>
        /// <returns>True when voice activity input is enabled in alt:V settings.</returns>
        [Obsolete("Use alt.Voice.activityInputEnabled instead.")]
        public static extern bool isVoiceActivityInputEnabled();

        /// <summary>
        /// Returns whether the specified key is toggled.
        /// </summary>
        /// <param name="key">Keycode</param>
        public static extern bool isKeyToggled(double key);

        /// <summary>
        /// Determines whether the specified key is pressed.
        /// </summary>
        /// <param name="key">Keycode</param>
        public static extern bool isKeyDown(double key);

        /// <summary>
        /// Returns state of user interface and console window.
        /// </summary>
        /// <returns>True when user interface or console window is opened.</returns>
        public static extern bool isMenuOpen();

        public static extern bool isTextureExistInArchetype(double modelHash, string modelName);

        /// <summary>
        /// Loads a model into memory synchronously.
        /// </summary>
        /// <param name="modelHash">Hash of the model.</param>
        public static extern void loadModel(double modelHash);

        /// <summary>
        /// Loads a model into memory asynchronously.
        /// </summary>
        /// <param name="modelHash">Hash of the model.</param>
        public static extern void loadModelAsync(double modelHash);

        /// <summary>
        /// Logs the specified arguments to the console.
        /// </summary>
        public static extern void log(params object[] args);

        /// <summary>
        /// Logs the specified arguments as an error to the console.
        /// </summary>
        public static extern void logError(params object[] args);

        /// <summary>
        /// Logs the specified arguments as a warning to the console.
        /// </summary>
        public static extern void logWarning(params object[] args);
        
        /// <summary>
        /// Schedules execution of handler on next frame.
        /// </summary>
        /// <param name="handler">Handler that should be scheduled for execution.</param>
        /// <returns>A number representing the id value of the timer that is set. Use this value with the <see cref="clearNextTick"/> function to cancel the timer.</returns>
        public static extern double nextTick(Action handler);
        
        /// <summary>
        /// Unsubscribes from client event with specified listener.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="listener">Listener that should be removed.</param>
        /// <remarks>Listener should be of the same reference as when event was subscribed.</remarks>
        public static extern void off(string eventName, JSCompiler.JSCallback listener);
        
        /// <summary>
        /// Unsubscribes from server event with specified listener.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="listener">Listener that should be removed.</param>
        /// <remarks>Listener should be of the same reference as when event was subscribed.</remarks>
        public static extern void offServer(string eventName, JSCompiler.JSCallback listener);
        
        /// <summary>
        /// Subscribes to client event with specified listener.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="listener">Listener that should be added.</param>
        public static extern void on(string eventName, JSCompiler.JSCallback listener);
        
        /// <summary>
        /// Subscribes to client event with specified listener, which only triggers once.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="listener">Listener that should be added.</param>
        public static extern void once(string eventName, JSCompiler.JSCallback listener);
        
        /// <summary>
        /// Subscribes to server event with specified listener.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="listener">Listener that should be added.</param>
        public static extern void onServer(string eventName, JSCompiler.JSCallback listener);
        
        /// <summary>
        /// Subscribes to server event with specified listener, which only triggers once.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="listener">Listener that should be added.</param>
        public static extern void onceServer(string eventName, JSCompiler.JSCallback listener);
        
        /// <summary>
        /// Removes the specified gxt text.
        /// </summary>
        /// <param name="key">Gxt text name.</param>
        public static extern void removeGxtText(string key);
        
        /// <summary>
        /// Unloads the specified ipl.
        /// </summary>
        /// <param name="iplName">Name of the ipl.</param>
        public static extern void removeIpl(string iplName);
        
        /// <summary>
        /// Loads the specified ipl.
        /// </summary>
        /// <param name="iplName">Name of the ipl.</param>
        public static extern void requestIpl(string iplName);
        
        /// <summary>
        /// The output is returned as a base64 string.
        /// </summary>
        /// <returns>Return is dependent on the success of the operation.</returns>
        public static extern Promise<string> takeScreenshot();
        
        /// <summary>
        /// The output is returned as a base64 string.
        /// </summary>
        /// <returns>Return is dependent on the success of the operation.</returns>
        /// <remarks>This only takes a screenshot of the raw GTA:V window. WebViews, game overlays etc. won't be captured.</remarks>
        public static extern Promise<string> takeScreenshotGameOnly();
        
        /// <summary>
        /// Resets a statistic to its default value.
        /// </summary>
        /// <param name="statName">Name of the statistic.</param>
        public static extern void resetStat(StatName statName);
        
        /// <summary>
        /// Freezes the camera in place so it doesn't change position or rotation.
        /// </summary>
        /// <param name="state">True to freeze the camera, false to unfreeze the camera.</param>
        /// <remarks> You can still move your character even if your camera is frozen.</remarks>
        public static extern void setCamFrozen(bool state);
        
        /// <summary>
        /// Sets the specified config flag to the specified state.
        /// </summary>
        /// <param name="flag">Config flag name.</param>
        /// <param name="state">Config flag state.</param>
        public static extern void setConfigFlag(string flag, bool state);
        
        /// <summary>
        /// Returns the state of the specified config flag.
        /// </summary>
        /// <param name="flag">Config flag name.</param>
        /// <returns>State of the specified config flag.</returns>
        public static extern bool getConfigFlag(string flag);
        
        /// <summary>
        /// Returns whether the specified config flag exists.
        /// </summary>
        /// <param name="flag">Config flag name.</param>
        /// <returns>True when the config flag exists.</returns>
        public static extern bool doesConfigFlagExist(string flag);
        
        /// <summary>
        /// Sets the current position of the cursor.
        /// </summary>
        /// <remarks>The cursor has to be visible for this to take effect.</remarks>
        public static extern void setCursorPos(Vector2 pos);
        
        /// <summary>
        /// Schedules execution of handler in specified intervals.
        /// </summary>
        /// <param name="handler">Handler that should be scheduled for execution.</param>
        /// <param name="milliseconds">The time, in milliseconds, between execution of specified handler.</param>
        /// <returns>A number representing the id value of the timer that is set. Use this value with the <see cref="clearInterval"/> function to cancel the timer.</returns>
        public static extern double setInterval(Action handler, double milliseconds);
        
        /// <summary>
        /// Sets the amount of real milliseconds that have to pass every game minute.
        /// </summary>
        public static extern void setMsPerGameMinute(double milliseconds);
        
        /// <summary>
        /// Sets the rotation velocity for the specified entity.
        /// </summary>
        /// <param name="scriptID">The script id of the entity.</param>
        /// <param name="x">The rotation velocity on the X axis.</param>
        /// <param name="y">The rotation velocity on the Y axis.</param>
        /// <param name="z">The rotation velocity on the Z axis.</param>
        public static extern void setRotationVelocity(double scriptID, double x, double y, double z);
        
        /// <summary>
        /// Sets a statistic to desired value.
        /// </summary>
        /// <param name="statName">Name of the statistic.</param>
        /// <param name="value">Value of the statistic you want to set.</param>
        public static extern void setStat(StatName statName, double value);
        
        /// <summary>
        /// Schedules execution of handler once after the expiration of interval.
        /// </summary>
        /// <param name="handler">Handler that should be scheduled for execution.</param>
        /// <param name="milliseconds">The time, in milliseconds, before execution of specified handler.</param>
        /// <returns>A number representing the id value of the timer that is set. Use this value with the <see cref="clearTimeout"/> function to cancel the timer.</returns>
        public static extern double setTimeout(Action handler, double milliseconds);
        
        /// <summary>
        /// Sets the current weather cycle.
        /// </summary>
        /// <param name="weathers">weathers An array containing the weather ids for the weather cycle.</param>
        /// <param name="multipliers">An array containing the multipliers for the weather cycle.</param>
        /// <remarks>
        /// This has to be activated after using it by using the <see cref="setWeatherSyncActive"/> function.
        /// The weathers and multipliers array has to be of the same length.
        /// </remarks>
        public static extern void setWeatherCycle(double[] weathers, double[] multipliers);
        
        /// <summary>
        /// Sets whether the weather sync is active.
        /// </summary>
        /// <param name="isActive">Whether the weather sync should be active.</param>
        /// <remarks>The weather sync has to be set by using the <see cref="setWeatherCycle"/> function.</remarks>
        public static extern void setWeatherSyncActive(bool isActive);
        
        /// <summary>
        /// Changes the visibility of cursor.
        /// </summary>
        /// <param name="state">A boolean indicating whenever cursor should be visible or not.</param>
        /// <remarks>This is handled by resource scoped internal integer, which gets increased/decreased by every function call. When you show your cursor 5 times, to hide it you have to do that 5 times accordingly.</remarks>
        public static extern void showCursor(bool state);
        
        /// <summary>
        /// Toggles the game controls.
        /// </summary>
        /// <param name="state">True to enable controls, false to disable controls.</param>
        /// <remarks>When this is set to false, all controls are disabled, so you can't move your character or the camera.</remarks>
        public static extern void toggleGameControls(bool state);
        
        public static extern void toggleVoiceControls(bool state);

        /// <summary>
        /// Load a specific ytyp file.
        /// </summary>
        /// <param name="path">Relative path to the game folder.</param>
        /// <example>
        /// alt.loadYtyp("x64u.rpf/levels/gta5/_hills/country_06/country_06_metadata.rpf/cs6_08_interior_cs6_08_mine_int.ytyp"
        /// </example>
        /// <remarks>alpha</remarks>
        public static extern bool loadYtyp(string path);

        /// <summary>
        /// Unload a specific ytyp file.
        /// </summary>
        /// <param name="path">Relative path to the game folder.</param>
        /// <example>
        /// alt.unloadYtyp("x64u.rpf/levels/gta5/_hills/country_06/country_06_metadata.rpf/cs6_08_interior_cs6_08_mine_int.ytyp"
        /// </example>
        /// <remarks>alpha</remarks>
        public static extern bool unloadYtyp(string path);
    }
}