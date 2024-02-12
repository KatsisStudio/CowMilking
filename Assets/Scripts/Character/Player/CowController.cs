using CowMilking.SO;
using System.Collections;
using UnityEngine;

namespace CowMilking.Character.Player
{
    public class CowController : ACharacter<CowInfo>
    {
        protected override int BaseHealth => 1;

        private void Start()
        {
            GetComponent<SpriteRenderer>().sprite = _info.Sprite;
            transform.Translate(Vector2.up * .5f);
            StartCoroutine(EatGrass());
        }

        private IEnumerator EatGrass()
        {
            while (true)
            {
                yield return new WaitForSeconds(_info.DelayBetweenSkill);

                GameManager.Instance.IncreaseGrass(1);
            }
        }
    }
}
