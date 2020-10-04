using System.Collections.Generic;
using UnityEngine;

namespace Status_System
{
    /// <summary>
    /// Any object that has this class as a component is capable of 
    /// having statuses effect it.
    /// </summary>
    public class StatusManager : MonoBehaviour
    {
        [SerializeField]
        private bool resetInflictionsOnOverlap;
        public List<Status> statuses { get; private set; }

        private void Awake()
        {
            statuses = new List<Status>();
        }

        private void Update()
        {
            foreach (Status status in statuses)
            {
                status.CheckStatus();
            }
        }

        /// <summary>
        /// Adds the given status to the list of Inflicted Statuses
        /// </summary>
        /// <param name="status">
        /// The Status to Inflict
        /// </param>
        public void InflictStatus(Status status)
        {
            Status oldStatus = GetStatus(status.statusType);
            if (oldStatus == null) statuses.Add(status);
            else if (resetInflictionsOnOverlap)
            {
                oldStatus.ResetStatus();
            }
        }

        /// <summary>
        /// Removes the given status from the list of Inflicted Statuses
        /// </summary>
        /// <param name="status">
        /// The status to remove
        /// </param>
        /// <returns>
        /// If the status was present to be removed
        /// </returns>
        public bool RemoveStatus(Status status)
        {
            return statuses.Remove(status);
        }

        /// <summary>
        /// Removes the Status based on the type.
        /// </summary>
        /// <param name="statusType"></param>
        /// <returns>
        /// The Status that was removed, or null if not there.
        /// </returns>
        public Status RemoveStatus(StatusType statusType)
        {
            Status status = GetStatus(statusType);
            return statuses.Remove(status) ? status : null;
        }

        /// <summary></summary>
        /// <param name="statusType"></param>
        /// <returns>
        /// The Status relating to the given type, or null 
        /// if a status of that type isn't applied.
        /// </returns>
        public Status GetStatus(StatusType statusType)
        {
            return statuses.Find(status => status.statusType == statusType);
        }
    }
}
