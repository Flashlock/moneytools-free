using System;
using UnityEngine;

namespace Damage_System
{
    /// <summary>
    /// Manages Health for the attached object.
    /// Allows the object to take damage, heal, die, respawn, etc.
    /// </summary>
    public abstract class HealthManager : MonoBehaviour
    {
        //Health Data
        [SerializeField]
        private int stdMaxHealth;
        public int maxHealthActual { get; protected set; }
        public int currentHealth { get; protected set; }

        //Spawn Data
        public Vector3 spawnPos;
        public Quaternion spawnRot;

        //If this has a HUD with a health bar, call this to update
        public Action<int, int> updateHealthBar;

        /// <summary>
        /// Sets maxHealthActual and currentHealth
        /// </summary>
        protected virtual void SetUp()
        {
            maxHealthActual = stdMaxHealth;
            currentHealth = maxHealthActual;
        }

        /// <summary>
        /// Receives damage from an attacker
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="attacker"></param>
        public virtual void TakeDamage(int damage, AttackManager attacker)
        {
            currentHealth -= damage;
            updateHealthBar?.Invoke(maxHealthActual, currentHealth);

            if (currentHealth <= 0)
                Die(attacker);
        }

        /// <summary>
        /// Receives damage
        /// </summary>
        /// <param name="damage"></param>
        public virtual void TakeDamage(int damage)
        {
            currentHealth -= damage;
            updateHealthBar?.Invoke(maxHealthActual, currentHealth);

            if (currentHealth <= 0)
                Die();
        }


        /// <summary>
        /// Receives health from a healer
        /// </summary>
        /// <param name="health"></param>
        /// <param name="healer"></param>
        public virtual void Heal(int health, AttackManager healer)
        {
            currentHealth += health;
            updateHealthBar?.Invoke(maxHealthActual, currentHealth);

            if (currentHealth > maxHealthActual)
                currentHealth = maxHealthActual;
        }

        /// <summary>
        /// Receives health
        /// </summary>
        /// <param name="health"></param>
        public virtual void Heal(int health)
        {
            currentHealth += health;
            updateHealthBar?.Invoke(maxHealthActual, currentHealth);

            if (currentHealth > maxHealthActual)
                currentHealth = maxHealthActual;
        }

        /// <summary>
        /// Dies by a killer
        /// </summary>
        /// <param name="killer"></param>
        public virtual void Die(AttackManager killer)
        {
            Destroy(gameObject);
        }

        /// <summary>
        /// Just dies
        /// </summary>
        public virtual void Die()
        {
            Destroy(gameObject);
        }

        /// <summary>
        /// Spawns the object at its spawn points
        /// </summary>
        public virtual void Spawn()
        {
            transform.position = spawnPos;
            transform.rotation = spawnRot;
        }
    }
}
