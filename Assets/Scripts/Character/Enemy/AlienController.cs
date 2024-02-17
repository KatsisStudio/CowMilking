using CowMilking.Persistency;
using CowMilking.SO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CowMilking.Character.Enemy
{
    public class AlienController : ACharacter<EnemyInfo>
    {
        private ICharacter _target;

        protected override int BaseHealth => _info.Health;

        private Rigidbody2D _rb;

        private float _attackTimer;

        private float _slowTimer;

        protected SpriteRenderer _sr;

        protected override void Init()
        {
            base.Init();

            _sr = GetComponent<SpriteRenderer>();
            _sr.sprite = _info.Sprite;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = _target == null ? (Vector2.left * _info.Speed * (_slowTimer > 0f ? .5f : 1f)) : Vector2.zero;
        }

        private void Update()
        {
            if (_target != null)
            {
                _attackTimer -= Time.deltaTime;
                if (_attackTimer <= 0f)
                {
                    _target.TakeDamage(1);
                    _attackTimer = _info.DelayBetweenAttacks;
                }
            }

            if (_slowTimer > 0f)
            {
                _slowTimer -= Time.deltaTime;
            }
        }

        public override void ApplySlow(float duration)
        {
            if (duration > _slowTimer)
            {
                _slowTimer = duration;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Obstacle"))
            {
                _target = collision.GetComponent<ICharacter>();

                _attackTimer = _info.DelayBetweenAttacks;
            }
            else if (collision.CompareTag("GameOver"))
            {
                WaveManager.Instance.BackToMenu();
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
