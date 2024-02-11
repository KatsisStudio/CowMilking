using CowMilking.SO;
using System.Collections;
using TMPro;
using UnityEngine;

namespace CowMilking.Character.Player
{
    public class CowController : ACharacter<CowInfo>
    {
        [SerializeField]
        private GameObject _infoUI;

        [SerializeField]
        private TMP_Text _nameText;

        protected override int BaseHealth => 1;

        private void Start()
        {
            _nameText.text = _info.name;
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
