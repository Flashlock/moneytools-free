using UnityEngine;

namespace CharControl_System
{
    [RequireComponent(typeof(Collider2D))]
    public class Eyes : MonoBehaviour
    {
        [SerializeField]
        private Collider2D sight;
        public LayerMask enemyMask, obstacleMask;

        private ICanSee brain;

        private void Awake()
        {
            brain = transform.parent.GetComponent<ICanSee>();
            sight.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == enemyMask)
            {
                brain.SpotTarget(collision.gameObject);
            }
            else if (collision.gameObject.layer == obstacleMask)
            {
                brain.SpotObstacle(collision.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == enemyMask)
            {
                brain.LostTarget(collision.gameObject);
            }
            else if (collision.gameObject.layer == obstacleMask)
            {
                brain.LostObstacle(collision.gameObject);
            }
        }
    }
}
