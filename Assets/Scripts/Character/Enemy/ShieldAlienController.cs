using UnityEngine;

namespace CowMilking.Character.Enemy
{
    public class ShieldAlienController : AlienController
    {
        [SerializeField]
        private Sprite _noShieldSprite;

        [SerializeField]
        private int _shieldHealth;

        private bool _hasShield = true;

        public override void ApplySlow(float duration)
        {
            if (_hasShield) return;

            base.ApplySlow(duration);
        }

        public override void TakeDamage(int amount)
        {
            if (_shieldHealth > 0)
            {
                _shieldHealth--;
                if (_shieldHealth == 0)
                {
                    _hasShield = false;
                    _sr.sprite = _noShieldSprite;
                }
            }
            else
            {
                base.TakeDamage(amount);
            }
        }
    }
}
