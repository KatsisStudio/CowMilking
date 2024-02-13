using UnityEngine;

namespace CowMilking.Character
{
    public interface ICharacter
    {
        public ScriptableObject Info { set; }
        public void TakeDamage(int amount);

        public int ID { get; }
    }
}
