using UnityEngine;

namespace CharControl_System
{
    /// <summary>
    /// This class is in charge of moving whatever RigidBody its atached to.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class CharacterController2D : MonoBehaviour
    {
        /*
         * Input and AI should be in another class, maybe CharacterMover.
         */

        //Movement Data
        [SerializeField]
        private float stdMaxSpeed, stdMaxAcceleration, stdMaxDecceleration, stdJumpForce;
        public float StdMaxSpeed
        {
            get { return stdMaxSpeed; }
            protected set { stdMaxSpeed = value; }
        }
        public float StdMaxAcceleration
        {
            get { return stdMaxAcceleration; }
            protected set { stdMaxAcceleration = value; }
        }
        public float StdMaxDecceleration
        {
            get { return stdMaxDecceleration; }
            protected set { stdMaxDecceleration = value; }
        }
        public float StdJumpForce
        {
            get { return stdJumpForce; }
            protected set { stdJumpForce = value; }
        }

        [SerializeField]
        private bool canControlInAir;
        public bool CanControlInAir
        {
            get { return canControlInAir; }
            protected set { canControlInAir = value; }
        }

        //Positioning Checks
        private bool isGrounded, isCeilinged;

        //How fast the character actually moves. These values should be used in performing movement
        protected float speedActual, accelActual, deccelActual, jumpForceActual;
        protected Rigidbody2D characterRB;

        /// <summary>
        /// This method sets up everything you'll need in a child class.
        /// It should be called in the Awake method of the child class.
        /// </summary>
        protected virtual void SetUp()
        {
            speedActual = stdMaxSpeed;
            accelActual = stdMaxAcceleration;
            deccelActual = stdMaxDecceleration;
            jumpForceActual = stdJumpForce;
            characterRB = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// Moves the rigidbody horizontally
        /// </summary>
        /// <param name="direction">
        /// 1 = right
        /// -1 = left
        /// 0 = stop/nothing
        /// </param>
        public virtual void MoveHorizontal(float direction)
        {
            Debug.LogError("This method must be overriden in a child class");
        }

        /// <summary>
        /// Moves the rigidbody vertically
        /// </summary>
        /// <param name="direction">
        /// 1 = right
        /// -1 = left
        /// 0 = stop/nothing
        /// </param>
        public virtual void MoveVertical(float direction)
        {
            Debug.LogError("This method must be overriden in a child class");
        }

        /// <summary>
        /// Jumps the character in a specific direction
        /// </summary>
        /// <param name="direction">
        /// The direction to jump in. Must be a Normal Vector
        /// </param>
        public virtual void Jump(Vector2 direction)
        {
            if (direction.sqrMagnitude != 1f)
            {
                Debug.LogError("Jump Direction not Normalized");
                return;
            }
            characterRB.AddForce(direction * jumpForceActual, ForceMode2D.Impulse);
        }

        /// <summary>
        /// Jumps the character
        /// </summary>
        public virtual void Jump()
        {
            Debug.LogError("This method must be overriden in a child class");
        }
    }
}
