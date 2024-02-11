using CowMilking.SO;
using UnityEngine;

namespace CowMilking.Character.Enemy
{
    public class AlienController : ACharacter
    {
        public EnemyInfo Info { set; private get; }

        protected override int BaseHealth => Info.Health;

        private Rigidbody2D _rb;

        protected override void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = Vector2.left * Info.Speed;
        }
    }
}
