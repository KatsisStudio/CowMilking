using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CowMilking.Questing
{
    [CreateAssetMenu(fileName = "New Quest", menuName = "ScriptableObject/Questing/Quest")]
    public class Quest : ScriptableObject
    {
        [SerializeField] protected string questName;

        [TextArea(5, 25)]
        [SerializeField] protected string questDescription;

        public bool questComplete { protected set; get; }

        [SerializeField] private Goal[] _goals;
        
        [System.Serializable] class QuestRewards 
        {
            public Rewards reward;
            public int amount;
        }

        [SerializeField] private QuestRewards[] _questRewards;

        public virtual void Initialize()
        {
            Debug.Log("Initializing Quest: " + questName);

            questComplete = false;

            foreach (Goal g in _goals)
            {
                g.Initialize(this);
            }
        }

        public void CheckAllGoalsCompleted()
        {
            foreach (Goal g in _goals)
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
            foreach(QuestRewards qr in _questRewards)
            {
                switch(qr.reward)
                {
                    case Rewards.Energy:
                        break;
                    case Rewards.Cow:
                        break;
                    case Rewards.FirePotion:
                        break;
                    case Rewards.WaterPotion:
                        break;
                    case Rewards.EarthPotion:
                        break;
                    case Rewards.WoodPotion:
                        break;
                    case Rewards.MetalPotion:
                        break;
                }
            }
        }
    }
}