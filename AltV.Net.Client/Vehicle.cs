using System.Collections.Generic;
using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class Vehicle : Entity
        {
            /// <summary>
            /// A list containing all vehicles in the world.
            /// </summary>
            public static readonly List<Vehicle> all;

            /// <summary>
            /// 
            /// </summary>
            public double gear { get; }

            /// <summary>
            /// 
            /// </summary>
            public IVehicleHandling handling { get; set; }

            /// <summary>
            /// Normalised rpm value on a scale of [0, 1].
            /// </summary>
            public double rpm { get; }

            public double speed { get; }
            public Vector3 speedVector { get; }
            public double wheelsCount { get; }

            /// <remarks>alpha</remarks>
            public bool isDestroyed { get; }

            /// <remarks>alpha</remarks>
            public double modKitsCount { get; }

            /// <remarks>alpha</remarks>
            public double modKit { get; }

            /// <remarks>alpha</remarks>
            public double primaryColor { get; }

            /// <remarks>alpha</remarks>
            public RGBA customPrimaryColor { get; }

            /// <remarks>alpha</remarks>
            public double secondaryColor { get; }

            /// <remarks>alpha</remarks>
            public RGBA customSecondaryColor { get; }

            /// <remarks>alpha</remarks>
            public double pearlColor { get; }

            /// <remarks>alpha</remarks>
            public double wheelColor { get; }

            /// <remarks>alpha</remarks>
            public double interiorColor { get; }

            /// <remarks>alpha</remarks>
            public double dashboardColor { get; }

            /// <remarks>alpha</remarks>
            public double tireSmokeColor { get; }

            /// <remarks>alpha</remarks>
            public double wheelType { get; }

            /// <remarks>alpha</remarks>
            public double frontWheels { get; }

            /// <remarks>alpha</remarks>
            public double rearWheels { get; }

            /// <remarks>alpha</remarks>
            public double customTires { get; }

            /// <remarks>alpha</remarks>
            public double darkness { get; }

            /// <remarks>alpha</remarks>
            public double numberPlateIndex { get; }

            /// <remarks>alpha</remarks>
            public string numberPlateText { get; }

            /// <remarks>alpha</remarks>
            public double windowTint { get; }

            /// <remarks>alpha</remarks>
            public double dirtLevel { get; }

            /// <remarks>alpha</remarks>
            public IVehicleNeon neon { get; }

            /// <remarks>alpha</remarks>
            public RGBA neonColor { get; }

            /// <remarks>alpha</remarks>
            public double livery { get; }

            /// <remarks>alpha</remarks>
            public double roofLivery { get; }

            /// <remarks>alpha</remarks>
            public bool engineOn { get; }

            /// <remarks>alpha</remarks>
            public bool handbrakeActive { get; }

            /// <remarks>alpha</remarks>
            public double headlightColor { get; }

            /// <remarks>alpha</remarks>
            public double activeRadioStation { get; }

            /// <remarks>alpha</remarks>
            public bool sirenActive { get; }

            /// <remarks>alpha</remarks>
            public double lockState { get; }

            /// <remarks>alpha</remarks>
            public bool daylightOn { get; }

            /// <remarks>alpha</remarks>
            public bool nightlightOn { get; }

            /// <remarks>alpha</remarks>
            public double roofState { get; }

            /// <remarks>alpha</remarks>
            public bool flamethrowerActive { get; }

            /// <remarks>alpha</remarks>
            public double lightsMultiplier { get; }

            /// <remarks>alpha</remarks>
            public double engineHealth { get; }

            /// <remarks>alpha</remarks>
            public double patrolTankHealth { get; }

            /// <remarks>alpha</remarks>
            public double repairsCount { get; }

            /// <remarks>alpha</remarks>
            public double bodyHealth { get; }

            /// <remarks>alpha</remarks>
            public double bodyAdditionalHealth { get; }

            /// <remarks>alpha</remarks>
            public bool hasArmoredWindows { get; }

            /// <remarks>alpha</remarks>
            public bool manualEngineControl { get; }

            /// <summary>
            /// private to deny custom construction.
            /// </summary>
            private extern Vehicle();

            /// <summary>
            /// Retrieves the vehicle from the pool.
            /// </summary>
            /// <param name="id">The id of the entity.</param>
            /// <returns>Entity if it was found, otherwise null.</returns>
            public static extern Vehicle getByID(double id);

            /// <summary>
            /// Retrieves the vehicle from the pool.
            /// </summary>
            /// <param name="scriptID">The script id of the entity.</param>
            /// <returns>Entity if it was found, otherwise null.</returns>
            public static extern Vehicle getByScriptID(double scriptID);
        }
    }
}