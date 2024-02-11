using CowMilking.Character;
using CowMilking.Character.Player;
using CowMilking.Map;
using CowMilking.SO;
using TMPro;
using UnityEngine;

namespace CowMilking
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { private set; get; }

        [SerializeField]
        private GameObject[] _hiddenUIUntilStart;
        [SerializeField]
        private GameObject[] _visibleUIUntilStart;

        [SerializeField]
        private TMP_Text _grassCount;

        [SerializeField]
        private PlacableInfoPanel _infoPanel;

        [SerializeField]
        private PlacementButton[] _placements;

        private void Awake()
        {
            Instance = this;

            foreach (var elem in _hiddenUIUntilStart)
            {
                elem.SetActive(false);
            }
        }

        public void ShowInfoPanel(ICharacter controller, CowInfo info)
        {
            _infoPanel.gameObject.SetActive(true);
            _infoPanel.Init(controller, info);
        }

        public void HideInfoPanel()
        {
            _infoPanel.gameObject.SetActive(false);
        }

        public void SetGrassAmount(int value)
        {
            _grassCount.text = $"{value}";

            foreach (var b in _placements)
            {
                b.ToggleInteraction(value);
            }
        }

        public void ToggleGameStartUI()
        {
            foreach (var elem in _hiddenUIUntilStart)
            {
                elem.SetActive(true);
            }
            foreach (var elem in _visibleUIUntilStart)
            {
                elem.SetActive(false);
            }
        }
    }
}
