using CowMilking.SO;
using UnityEngine;

namespace CowMilking.Enemy
{
    public class AlienController : MonoBehaviour
    {
        public EnemyInfo Info { set; private get; }

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = Vector2.left * Info.Speed;
        }
    }
}
