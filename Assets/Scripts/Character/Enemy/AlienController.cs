using CowMilking.SO;
using UnityEngine;

namespace CowMilking.Character.Enemy
{
    public class AlienController : ACharacter<EnemyInfo>
    {
        private ICharacter _target;

        protected override int BaseHealth => _info.Health;

        private Rigidbody2D _rb;

        private float _attackTimer;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = _target == null ? Vector2.left * _info.Speed : Vector2.zero;
        }

        private void Update()
        {
            if (_target != null)
            {
                _attackTimer -= Time.deltaTime;
                if (_attackTimer <= 0f)
                {
                    _target.TakeDamage();
                    _attackTimer = _info.DelayBetweenAttacks;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Obstacle"))
            {
                _target = collision.GetComponent<ICharacter>();

                _attackTimer = _info.DelayBetweenAttacks;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Obstacle"))
            {
                var other = collision.GetComponent<ICharacter>();
                if (_target != null && other.ID == _target.ID)
                {
                    _target = null;
                }
            }
        }
    }
}
