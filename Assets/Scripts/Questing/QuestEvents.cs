using CowMilking.SO;
using UnityEngine;

namespace CowMilking.Questing
{
    public class QuestEvents : MonoBehaviour
    {
        public static QuestEvents Instance { private set; get; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
            {
                Destroy(this);
            }
        }

        public delegate void CowMilked(CowInfo cowInfo);
        public static event CowMilked OnCowMilked;

        public void MilkedACow(CowInfo cowInfo)
        {
            Debug.Log("A cow has been milked of element: " + cowInfo.Element);

            if (OnCowMilked != null)
                OnCowMilked.Invoke(cowInfo);
        }

        public delegate void AlienKilled(CowInfo cowInfo);
        public static event AlienKilled OnAlienKilled;

        public void KilledAnAlien(CowInfo cowInfo)
        {
            if (OnAlienKilled != null)
                OnAlienKilled.Invoke(cowInfo);
        }

        public delegate void CowBought();
        public static event CowBought OnCowBought;

        public void BoughtACow()
        {
            if (OnCowBought != null)
                OnCowBought.Invoke();
        }

        public delegate void CowUpgraded(CowInfo cowInfo);
        public static event CowUpgraded OnCowUpgraded;

        public void UpgradedACow(CowInfo cowInfo)
        {
            if (OnCowUpgraded != null)
                OnCowUpgraded.Invoke(cowInfo);
        }

    }
}