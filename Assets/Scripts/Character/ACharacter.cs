using UnityEngine;

namespace CowMilking.Character
{
    public abstract class ACharacter<T> : MonoBehaviour, ICharacter
        where T : ScriptableObject
    {

        protected T _info;
        public ScriptableObject Info
        {
            set
            {
                _info = (T)value;
                Init();
            }
        }

        public int ID => GetInstanceID();

        protected int _health;

        protected abstract int BaseHealth { get; }

        protected virtual void Init()
        {
            _health = BaseHealth;
        }

        public virtual void TakeDamage(int amount)
        {
            _health -= amount;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }

        public virtual void ApplySlow(float duration)
        { }
    }
}
