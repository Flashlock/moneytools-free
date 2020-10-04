using UnityEngine;

namespace Status_System
{
    /// <summary>
    /// The type of Status being applied.
    /// </summary>
    public enum StatusType { };

    /// <summary>
    /// Statuses can affect a variety of things (like in Pokemon)
    /// Specific statuses should derive from this class and overide methods as necessary
    /// </summary>
    [System.Serializable]
    public abstract class Status
    {
        //Type and Ownership
        public StatusType statusType;
        [HideInInspector]
        public StatusManager target;    //the status is inflicted upon the target
        public GameObject owner;        //the status is inflicted by the owner

        //Status Duration
        public float statusDuration;
        private float statusClock;

        //Constructor
        public Status(StatusType statusType, GameObject owner, float statusDuration)
        {
            this.statusType = statusType;
            this.owner = owner;
            this.statusDuration = statusDuration;
        }

        /// <summary>
        /// Should be called in the target's Update function.
        /// Applies whatever status affecets have been given, and 
        /// removes itself once the duration is complete
        /// </summary>
        /// <returns>
        /// If the status is still being applied
        /// </returns>
        public virtual bool CheckStatus()
        {
            if (statusClock < statusDuration)
            {
                statusClock += Time.deltaTime;
                return true;
            }
            else
            {
                target.RemoveStatus(this);
                return false;
            }
        }

        /// <summary>
        /// Resets the status clock.
        /// Used when the same status is applied twice.
        /// </summary>
        public void ResetStatus()
        {
            statusClock = 0f;
        }

        /// <summary></summary>
        /// <returns>
        /// Returns a copy of the status.
        /// Could be used when something needs its own copy of a status to play with
        /// </returns>
        public virtual Status CopyStatus()
        {
            Debug.LogError("This method must be overriden in a child class");
            return null;
        }
    }
}
