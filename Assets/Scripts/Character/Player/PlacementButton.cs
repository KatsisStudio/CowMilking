using CowMilking.SO;
using UnityEngine;
using UnityEngine.UI;

namespace CowMilking.Character.Player
{
    public class PlacementButton : MonoBehaviour
    {
        public SpawnableInfo Info { set; private get; }

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void OnClick()
        {
            GameManager.Instance.OnObjectSelection(Info);
        }

        public void ToggleInteraction(int grassAvailable)
        {
            _button.interactable = grassAvailable >= Info.Cost;
        }
    }
}
