using UnityEngine;

namespace CowMilking.Character
{
    public abstract class ACharacter : MonoBehaviour
    {
        private int _health;

        protected abstract int BaseHealth { get; }

        protected virtual void Awake()
        {
            _health = BaseHealth;
        }

        public void TakeDamage()
        {
            _health--;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
