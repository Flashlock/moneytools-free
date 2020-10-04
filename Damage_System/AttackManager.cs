using System.Collections.Generic;
using UnityEngine;

namespace Damage_System
{
    /// <summary>
    /// Manages a List of Attacks this Object can perform.
    /// </summary>
    public abstract class AttackManager : MonoBehaviour
    {
        [SerializeField]
        private List<Attack> attacks;
        public List<Attack> Attacks
        {
            get { return attacks; }
            private set { attacks = value; }
        }

        /// <summary>
        /// Finds and returns the Attack based on the tag
        /// Actually using the attack will have to be overriden
        /// </summary>
        /// <param name="attackTag"></param>
        /// <returns></returns>
        public virtual Attack UseAttack(string attackTag)
        {
            Attack atk = attacks.Find(attack => attack.attackTag.CompareTo(attackTag) == 0);
            if (atk == null)
                Debug.LogError("Attack Not Found");
            return atk;
        }
    }
}
