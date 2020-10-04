namespace Damage_System
{
    /// <summary>
    /// The base class for all attacks.
    /// </summary>
    [System.Serializable]
    public abstract class Attack
    {
        /*
         * There likely needs to be an animation attached as well, but I'll leave it off
         * so the user can decide if they want an animation or a tween or something.
         * This also may or may not need need to attach to a game object, or spawn in a game object
         */

        public string attackTag;
        public AttackManager owner;
    }
}
