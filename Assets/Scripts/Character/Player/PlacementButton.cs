using CowMilking.SO;
using UnityEngine;
using UnityEngine.UI;

namespace CowMilking.Character.Player
{
    public class PlacementButton : MonoBehaviour
    {
        [SerializeField]
        private SpawnableInfo _info;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void OnClick()
        {
            GameManager.Instance.OnObjectSelection(_info);
        }

        public void ToggleInteraction(int grassAvailable)
        {
            _button.interactable = grassAvailable >= _info.Cost;
        }
    }
}
