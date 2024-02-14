using UnityEngine;

namespace CowMilking.Character.Enemy
{
    public class ShieldAlienController : AlienController
    {
        [SerializeField]
        private Sprite _noShieldSprite;

        private bool _hasShield = true;

        public override void ApplySlow(float duration)
        {
            if (_hasShield) return;

            base.ApplySlow(duration);
        }

        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);

            if (_hasShield && _health <= BaseHealth / 2f)
            {
                _hasShield = false;
                _sr.sprite = _noShieldSprite;
            }
        }
    }
}
