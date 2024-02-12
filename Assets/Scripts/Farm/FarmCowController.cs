using CowMilking.SO;
using System.Collections;
using UnityEngine;

namespace CowMilking.Farm
{
    public class FarmCowController : MonoBehaviour
    {
        public CowInfo Info { set; get; }

        private Rigidbody2D _rb;
        private SpriteRenderer _sr;

        private int _cowLayer;

        private Camera _cam;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _sr = GetComponent<SpriteRenderer>();
            _cowLayer = LayerMask.NameToLayer("Cow");
            _cam = Camera.main;

            StartCoroutine(WalkAround());
        }

        private Bounds CalculateBounds()
        {
            float screenAspect = Screen.width / (float)Screen.height;
            float cameraHeight = _cam.orthographicSize * 2;
            Bounds bounds = new(
                _cam.transform.position,
                new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
            return bounds;
        }

        private IEnumerator WalkAround()
        {
            while (true)
            {
                _rb.velocity = Random.insideUnitCircle.normalized * 1f;
                yield return new WaitForSeconds(Random.Range(1f, 3f));
            }
        }

        private float EnsureNegative(float value) => value < 0f ? value : -value;
        private float EnsurePositive(float value) => value < 0f ? -value : value;

        private void Update()
        {
            _sr.sortingOrder = (int)(-transform.position.y * 100f + 10_000_000f);

            var bounds = CalculateBounds();
            var p = transform.position;

            if (p.x > bounds.max.x) _rb.velocity = new(EnsureNegative(_rb.velocity.x), _rb.velocity.y);
            else if (p.x < bounds.min.x) _rb.velocity = new(EnsurePositive(_rb.velocity.x), _rb.velocity.y);

            if (p.y > bounds.max.y) _rb.velocity = new(_rb.velocity.x, EnsureNegative(_rb.velocity.y));
            else if (p.y < bounds.min.y) _rb.velocity = new(_rb.velocity.x, EnsurePositive(_rb.velocity.y));
        }

        public void Allow()
        {
            _sr.color = Color.white;
            gameObject.layer = _cowLayer;
        }

        public void Disallow()
        {
            _sr.color = Color.gray;
            gameObject.layer = 0;
        }
    }
}
