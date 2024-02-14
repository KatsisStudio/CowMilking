using CowMilking.SO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CowMilking.Character.Player
{
    public class PlacementButton : MonoBehaviour
    {
        private CowInfo _info;
        private Button _button;

        public void Init(CowInfo info)
        {
            _info = info;
            _button = GetComponent<Button>();
            GetComponentInChildren<TMP_Text>().text = $"{_info.Name}\nCost: {_info.Cost}";
        }

        public void OnClick()
        {
            GameManager.Instance.OnObjectSelection(_info, this);
        }

        public void ToggleInteraction(int grassAvailable)
        {
            _button.interactable = grassAvailable >= _info.Cost;
        }
    }
}
