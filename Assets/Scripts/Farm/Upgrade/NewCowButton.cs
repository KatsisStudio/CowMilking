using CowMilking.Persistency;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CowMilking.Farm.Upgrade
{
    public class NewCowButton : MonoBehaviour, IUpdatableUI
    {
        private const int CostRequirement = 20;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();

            GetComponentInChildren<TMP_Text>().text += $"\nCost: {CostRequirement}";

            UpdateUI();
        }

        public void UpdateUI()
        {
            _button.interactable = PersistencyManager.Instance.SaveData.Energy >= CostRequirement;
        }

        public void OnClick()
        {
            PersistencyManager.Instance.SaveData.OwnedCows.Add("NEUTRAL");
            PersistencyManager.Instance.SaveData.Energy -= CostRequirement;
            PersistencyManager.Instance.Save();

            FarmManager.Instance.AddNewCow("NEUTRAL");

            UpdateUI();
        }
    }
}
