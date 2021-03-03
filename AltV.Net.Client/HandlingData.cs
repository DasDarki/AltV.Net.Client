using System;
using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class HandlingData
        {
            public double handlingNameHash { get; }
            public double acceleration { get; set; }
            public double antiRollBarBiasFront { get; set; }
            public double antiRollBarBiasRear { get; set; }
            public double antiRollBarForce { get; set; }
            public double brakeBiasFront { get; set; }
            public double brakeBiasRear { get; set; }
            public double brakeForce { get; set; }
            public double camberStiffnesss { get; set; }
            public Vector3 centreOfMassOffset { get; set; }
            public double clutchChangeRateScaleDownShift { get; set; }
            public double clutchChangeRateScaleUpShift { get; set; }
            public double collisionDamageMult { get; set; }
            public double damageFlags { get; set; }
            public double deformationDamageMult { get; set; }
            public double downforceModifier { get; set; }
            public double driveBiasFront { get; set; }
            public double driveInertia { get; set; }
            public double driveMaxFlatVel { get; set; }
            public double engineDamageMult { get; set; }
            public double handBrakeForce { get; set; }
            public double handlingFlags { get; set; }
            public Vector3 inertiaMultiplier { get; set; }
            public double initialDragCoeff { get; set; }
            public double initialDriveForce { get; set; }
            public double initialDriveGears { get; set; }
            public double initialDriveMaxFlatVel { get; set; }
            public double lowSpeedTractionLossMult { get; set; }
            public double mass { get; set; }
            public double modelFlags { get; set; }
            public double monetaryValue { get; set; }
            public double oilVolume { get; set; }
            public double percentSubmerged { get; set; }
            public double percentSubmergedRatio { get; set; }
            public double petrolTankVolume { get; set; }
            public double rollCentreHeightFront { get; set; }
            public double rollCentreHeightRear { get; set; }
            public double seatOffsetDistX { get; set; }
            public double seatOffsetDistY { get; set; }
            public double seatOffsetDistZ { get; set; }
            public double steeringLock { get; set; }
            public double steeringLockRatio { get; set; }
            public double suspensionBiasFront { get; set; }
            public double suspensionBiasRear { get; set; }
            public double suspensionCompDamp { get; set; }
            public double suspensionForce { get; set; }
            public double suspensionLowerLimit { get; set; }
            public double suspensionRaise { get; set; }
            public double suspensionReboundDamp { get; set; }
            public double suspensionUpperLimit { get; set; }
            public double tractionBiasFront { get; set; }
            public double tractionBiasRear { get; set; }
            public double tractionCurveLateral { get; set; }
            public double tractionCurveLateralRatio { get; set; }
            public double tractionCurveMax { get; set; }
            public double tractionCurveMaxRatio { get; set; }
            public double tractionCurveMin { get; set; }
            public double tractionCurveMinRatio { get; set; }
            public double tractionLossMult { get; set; }
            public double tractionSpringDeltaMax { get; set; }
            public double tractionSpringDeltaMaxRatio { get; set; }
            public double unkFloat1 { get; set; }
            public double unkFloat2 { get; set; }
            public double unkFloat4 { get; set; }
            public double unkFloat5 { get; set; }
            public double weaponDamageMult { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="HandlingData"/> class that can modify handling properties for the specified handling name.
            /// </summary>
            public static extern HandlingData getForHandlingName(double handlingHash);

            /// <summary>
            /// Initializes a new instance of the <see cref="HandlingData"/> class that can modify handling properties for the specified handling name.
            /// </summary>
            [Obsolete("Use HandlingData#getForHandlingName()")]
            public static extern HandlingData getForModelName(double handlingHash);
        }
    }
}