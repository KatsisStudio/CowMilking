using CowMilking.SO;
using UnityEngine;
using UnityEngine.UI;

namespace CowMilking.Character.Player
{
    public class PlacementButton : MonoBehaviour
    {
        public SpawnableInfo Info { set; get; }

        [SerializeField]
        private Button _button;

        [SerializeField]
        private Transform _container;

        [SerializeField]
        private GameObject _buttonPrefab;

        public void OnClick()
        {
            GameManager.Instance.OnObjectSelection(Info, this);
        }

        public void ToggleInteraction(int grassAvailable)
        {
            _button.interactable = grassAvailable >= Info.Cost;
        }
    }
}
