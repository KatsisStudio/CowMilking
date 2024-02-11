using System.Collections;
using UnityEngine;

namespace CowMilking.Character.Player
{
    public class CowController : ACharacter
    {
        protected override int BaseHealth => 1;

        private void Awake()
        {
            Init();
            StartCoroutine(EatGrass());
        }

        private IEnumerator EatGrass()
        {
            while (true)
            {
                yield return new WaitForSeconds(2f); // TODO: SO

                GameManager.Instance.IncreaseGrass(1);
            }
        }
    }
}
