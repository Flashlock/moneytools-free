using UnityEngine;

namespace CharControl_System
{
    /// <summary>
    /// An interface for all Enemy Controllers that can see
    /// </summary>
    public interface ICanSee
    {
        /// <summary>
        /// My eyes have spotted an enemy.
        /// </summary>
        /// <param name="target">
        /// The enemy.
        /// </param>
        void SpotTarget(GameObject target);

        /// <summary>
        /// My eyes have lost sight of an enemy.
        /// </summary>
        /// <param name="target">
        /// The enemy.
        /// </param>
        void LostTarget(GameObject target);

        /// <summary>
        /// My eyes have spotted an obstacle in my path.
        /// </summary>
        /// <param name="obstacle">
        /// The obstacle.
        /// </param>
        void SpotObstacle(GameObject obstacle);

        /// <summary>
        /// My eyes have lost sight of an obstacle.
        /// </summary>
        /// <param name="obstacle">
        /// The obstacle.
        /// </param>
        void LostObstacle(GameObject obstacle);
    }
}
