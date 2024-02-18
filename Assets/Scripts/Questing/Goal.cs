using CowMilking.Character.Player;
using UnityEngine;

namespace CowMilking.Questing
{
    public class Goal : ScriptableObject
    {
        public int goalID { private set; get; }

        public string goalSummary;

        public int requiredAmount;
        public ElementType requiredElement;

        public bool completed { protected set; get; }

        //Quest i am associated with
        protected Quest quest;

        public virtual void Initialize(Quest q, int id)
        {
            completed = false;
            quest = q;
            goalID = id;
        }

        public virtual void Complete()
        {
            Debug.Log("Completed Goal");

            //I am completed
            completed = true;
            
            //Check if all quest goals completed
            quest.CheckAllGoalsCompleted();
        }

        public virtual void ResetGoal()
        {
            completed = false;
        }

    }
}
