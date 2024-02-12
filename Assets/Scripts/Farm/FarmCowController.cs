using System.Collections;
using UnityEngine;

namespace CowMilking.Farm
{
    public class FarmCowController : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private SpriteRenderer _sr;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();

            StartCoroutine(WalkAround());
        }

        private IEnumerator WalkAround()
        {
            while (true)
            {
                _rb.velocity = Random.insideUnitCircle.normalized * 1f;
                yield return new WaitForSeconds(Random.Range(1f, 3f));
            }
        }

        private void Update()
        {
            _sr.sortingOrder = (int)(-transform.position.y * 100f + 10_000_000f);
        }
    }
}
