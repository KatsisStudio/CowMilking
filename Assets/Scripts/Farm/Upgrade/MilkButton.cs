using CowMilking.Persistency;
using UnityEngine;
using UnityEngine.UI;

namespace CowMilking.Farm.Upgrade
{
    public class MilkButton : MonoBehaviour, IUpdatableUI
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            UpdateUI();
        }

        public void UpdateUI()
        {
            _button.interactable = PersistencyManager.Instance.SaveData.Energy >= 50;
        }
    }
}
