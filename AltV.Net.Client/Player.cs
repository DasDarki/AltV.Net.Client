using System.Collections.Generic;
using JavaScript.NET;

namespace AltV.Net.Client
{
    public partial class alt
    {
        [JSExclude]
        public class Player : Entity
        {
            /// <summary>
            /// A list containing all players in the world.
            /// </summary>
            public static readonly List<Player> all;

            /// <summary>
            /// The local player of this client-side.
            /// </summary>
            public static readonly Player local;

            /// <summary>
            /// Player talking state.
            /// </summary>
            public bool isTalking { get; }

            /// <summary>
            /// Player talking volume.
            /// </summary>
            public bool micLevel { get; }

            /// <summary>
            /// Player name.
            /// </summary>
            public string name { get; }

            /// <summary>
            /// Player's vehicle, null if player is not in any vehicle.
            /// </summary>
            public Vehicle vehicle { get; }

            /// <summary>
            /// Current weapon components.
            /// </summary>
            public List<double> currentWeaponComponents { get; }

            /// <summary>
            /// Currently equipped weapon.
            /// </summary>
            public double currentWeapon { get; }

            /// <summary>
            /// Is the player currently in ragdoll.
            /// </summary>
            public bool isInRagdoll { get; }

            /// <summary>
            /// Is the player currently aiming.
            /// </summary>
            /// <remarks>
            /// Returns ``true`` _ONLY_ if:
            /// - you are in first person with a gun equipped and you are not sprinting
            /// - you are in third person and aiming/shooting
            /// </remarks>
            public bool isAiming { get; }

            /// <summary>
            /// Current armour.
            /// </summary>
            public double armour { get; }

            /// <summary>
            /// Max available armour value.
            /// </summary>
            public double maxArmour { get; }

            /// <summary>
            /// Current player movement speed.
            /// </summary>
            public double moveSpeed { get; }

            /// <summary>
            /// Position the player is currently aiming at.
            /// </summary>
            public Vector3 aimPos { get; }

            /// <summary>
            /// Rotation of the head of the player.
            /// </summary>
            public Vector3 headRot { get; }

            /// <summary>
            /// Current seat the player is sitting in.
            /// </summary>
            public double seat { get; }

            /// <summary>
            /// The entity the player is aiming at.
            /// </summary>
            public Entity entityAimingAt { get; }

            /// <summary>
            /// The current aim offset of the player.
            /// </summary>
            public Vector3 entityAimOffset { get; }

            /// <summary>
            /// Is the flashlight of the player activated.
            /// </summary>
            public bool flashlightActive { get; }

            /// <summary>
            /// Current health of the player.
            /// </summary>
            public double health { get; }

            /// <summary>
            /// Current max health of the player.
            /// </summary>
            public double maxHealth { get; }

            /// <summary>
            /// Set & get the volume for 3D Voice.
            /// </summary>
            /// <remarks>Value needs to be between 0-1.</remarks>
            public double spatialVolume { get; }

            /// <summary>
            /// Set & get the volume for 2D Voice.
            /// </summary>
            /// <remarks>Value needs to be between 0-1.</remarks>
            public double nonSpatialVolume { get; }

            /// <summary>
            /// Tint index for currently equipped weapon.
            /// </summary>
            /// <remarks>alpha</remarks>
            public double currentWeaponTintIndex { get; }

            /// <summary>
            /// Is the player currently jumping.
            /// </summary>
            /// <remarks>alpha</remarks>
            public bool isJumping { get; }

            /// <summary>
            /// Is the player currently shooting with a weapon.
            /// </summary>
            /// <remarks>alpha</remarks>
            public bool isShooting { get; }

            /// <summary>
            /// Is the player currently reloading their weapon.
            /// </summary>
            /// <remarks>alpha</remarks>
            public bool isReloading { get; }

            /// <summary>
            /// private to deny custom construction.
            /// </summary>
            private extern Player();

            /// <summary>
            /// Retrieves the player from the pool.
            /// </summary>
            /// <param name="id">The id of the entity.</param>
            /// <returns>Entity if it was found, otherwise null.</returns>
            public static extern Player getByID(double id);

            /// <summary>
            /// Retrieves the player from the pool.
            /// </summary>
            /// <param name="scriptID">The script id of the entity.</param>
            /// <returns>Entity if it was found, otherwise null.</returns>
            public static extern Player getByScriptID(double scriptID);
        }
    }
}