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

        private void Awake()
        {
            Instance = this;
        }

        public void SetGrassAmount(int value)
        {
            _grassCount.text = $"{value}";
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
