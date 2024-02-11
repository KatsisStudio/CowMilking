using CowMilking.Character;
using CowMilking.SO;
using TMPro;
using UnityEngine;

namespace CowMilking.Map
{
    public class PlacableInfoPanel : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _nameText;

        public void Init(ICharacter controller, CowInfo info)
        {
            _nameText.text = info.Name;
        }
    }
}
