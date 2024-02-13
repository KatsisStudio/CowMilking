using CowMilking.SO;
using UnityEngine;

namespace CowMilking.Character.Player
{
    public class Bullet : MonoBehaviour
    {
        private CowInfo _info;
        public CowInfo Info
        {
            set
            {
                _info = value;

                GetComponent<SpriteRenderer>().color = value.Color;
                GetComponent<Rigidbody2D>().velocity = Vector2.right * 3f;
            }
            get => _info;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            collision.GetComponent<ICharacter>().TakeDamage(_info.Damage);
            Destroy(gameObject);
        }
    }
}
