using CowMilking.Farm;
using CowMilking.Persistency;
using UnityEngine;

namespace CowMilking.Questing
{
    [CreateAssetMenu(fileName = "New Quest", menuName = "ScriptableObject/Questing/Quest")]
    public class Quest : ScriptableObject
    {
        private static int key = 0;

        public int questID { private set; get; }

        public string questName;

        [TextArea(5, 25)]
        [SerializeField] protected string questDescription;

        public bool questComplete;

        public Goal[] goals;
        
        [System.Serializable] public class QuestRewards 
        {
            public Rewards reward;
            public int amount;
        }

        [SerializeField] public QuestRewards[] questRewards;

        public virtual void Initialize()
        {

            questID = key;
            key++;

            questComplete = false;

            for (int i = 0; i < goals.Length; i++)
            {
                goals[i].Initialize(this, i);
            }
        }

        public void CheckAllGoalsCompleted()
        {
            foreach (Goal g in goals)
            {
                if (!g.completed)
                {
                    return;
                }
            }
            Completed();
        }

        protected virtual void Completed()
        {
            questComplete = true;
            GrantReward();
        }

        protected virtual void GrantReward()
        {
            foreach(QuestRewards qr in questRewards)
            {
                switch(qr.reward)
                {
                    case Rewards.Energy:
                        PersistencyManager.Instance.SaveData.Energy += qr.amount;
                        break;
                    case Rewards.Cow:
                        PersistencyManager.Instance.SaveData.OwnedCows.Add("NEUTRAL");
                        FarmManager.Instance.AddNewCow("NEUTRAL");
                        break;
                    case Rewards.FirePotion:
                        PersistencyManager.Instance.SaveData.Potions.Add(Character.Player.ElementType.Fire, qr.amount);
                        break;
                    case Rewards.WaterPotion:
                        PersistencyManager.Instance.SaveData.Potions.Add(Character.Player.ElementType.Water, qr.amount);
                        break;
                    case Rewards.EarthPotion:
                        PersistencyManager.Instance.SaveData.Potions.Add(Character.Player.ElementType.Earth, qr.amount);
                        break;
                    case Rewards.WoodPotion:
                        PersistencyManager.Instance.SaveData.Potions.Add(Character.Player.ElementType.Wood, qr.amount);
                        break;
                    case Rewards.MetalPotion:
                        PersistencyManager.Instance.SaveData.Potions.Add(Character.Player.ElementType.Metal, qr.amount);
                        break;
                }
            }
            
            foreach(Goal g in goals)
            {
                //Resets all goals and quest to allow farming of potions
                //Not ideal since we at the moment don't get proper update on quest completion
                //TOAST message?
                g.ResetGoal();
            }
        }

        public string GetQuestDescription()
        {
            return questDescription;
        }

        public void SaveQuest()
        {
            Quest quest = new Quest();
        }
    }
}