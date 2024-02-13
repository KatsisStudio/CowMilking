using CowMilking.SO;
using System.Collections;
using UnityEngine;

namespace CowMilking.Character.Player
{
    public class CowController : ACharacter<CowInfo>
    {
        [SerializeField]
        private GameObject _bulletPrefab;

        protected override int BaseHealth => 1;

        private void Start()
        {
            GetComponent<SpriteRenderer>().sprite = _info.Sprite;
            transform.Translate(Vector2.up * .5f);

            if (_info.EatGrass)
            {
                StartCoroutine(EatGrass());
            }

            if (_info.FireBullet)
            {
                StartCoroutine(FireBullet());
            }
        }

        private IEnumerator EatGrass()
        {
            while (true)
            {
                yield return new WaitForSeconds(_info.DelayBetweenGrassEating);

                GameManager.Instance.IncreaseGrass(1);
            }
        }

        private IEnumerator FireBullet()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);

                var go = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
                go.GetComponent<Bullet>().Info = _info;
            }
        }
    }
}
