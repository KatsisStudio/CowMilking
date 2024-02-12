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
            Debug.Log(questName + " completed!");
            questComplete = true;
            GrantReward();
        }

        protected virtual void GrantReward()
        {
            Debug.Log("Granting reward for quest: " + questName);
        }
    }
}