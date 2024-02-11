using UnityEngine;

namespace CowMilking.Character
{
    public interface ICharacter
    {
        public ScriptableObject Info { set; }
        public void TakeDamage();

        public int ID { get; }
    }
}
