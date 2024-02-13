using CowMilking.SO;
using UnityEngine;
using UnityEngine.UI;

namespace CowMilking.Character.Player
{
    public class PlacementButton : MonoBehaviour
    {
        public SpawnableInfo Info { set; get; }

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void OnClick()
        {
            GameManager.Instance.OnObjectSelection(Info, this);
        }

        public void ToggleInteraction(int grassAvailable)
        {
            if (_button == null)
            {
                Awake(); // TODO: I'm a lazy fuck
            }
            _button.interactable = grassAvailable >= Info.Cost;
        }
    }
}
