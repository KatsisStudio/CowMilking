using CowMilking.Character;
using CowMilking.Character.Player;
using CowMilking.Map;
using CowMilking.Persistency;
using CowMilking.SO;
using System.Collections.Generic;
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
        private Transform _mainContainer;

        [SerializeField]
        private GameObject _dropDownPrefab, _buttonPrefab;

        private readonly List<PlacementButton> _placements = new();

        private void Awake()
        {
            Instance = this;

            foreach (var elem in _hiddenUIUntilStart)
            {
                elem.SetActive(false);
            }
        }

        private void Start()
        {
            Dictionary<ElementType, PlacementDropDown> menu = new();
            foreach (var cow in PersistencyManager.Instance.SaveData.OwnedCows)
            {
                var info = CowManager.Instance.GetCow(cow);
                if (!menu.ContainsKey(info.Element))
                {
                    var go = Instantiate(_dropDownPrefab, _mainContainer);
                    var pdd = go.GetComponent<PlacementDropDown>();
                    pdd.GetComponentInChildren<TMP_Text>().text = info.Element.ToString();

                    menu.Add(info.Element, pdd);
                }

                var container = menu[info.Element].Container;
                var gobtn = Instantiate(_buttonPrefab, container);
                var pb = gobtn.GetComponent<PlacementButton>();
                pb.Init(info);

                _placements.Add(pb);
            }

            GameManager.Instance.UpdateUI();
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
