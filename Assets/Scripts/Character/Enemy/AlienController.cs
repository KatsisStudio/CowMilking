using CowMilking.Character.Player;
using CowMilking.SO;
using UnityEngine;

namespace CowMilking.Character.Enemy
{
    public class AlienController : ACharacter
    {
        public EnemyInfo Info { set; private get; }

        private ACharacter _target;

        protected override int BaseHealth => Info.Health;

        private Rigidbody2D _rb;

        protected override void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = _target == null ? Vector2.left * Info.Speed : Vector2.zero;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Obstacle"))
            {
                _target = collision.GetComponent<ACharacter>();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Obstacle"))
            {
                var other = collision.GetComponent<ACharacter>();
                if (_target != null && other.GetInstanceID() == _target.GetInstanceID())
                {
                    _target = null;
                }
            }
        }
    }
}
