using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CowMilking.Questing
{
    public class Goal : ScriptableObject
    {
        public bool completed { protected set; get; }

        //Quest i am associated with
        protected Quest _quest;

        public virtual void Initialize(Quest q)
        {
            completed = false;
            _quest = q;
        }

        public virtual void Complete()
        {
            Debug.Log("Completed Goal");

            //I am completed
            completed = true;
            
            //Check if all quest goals completed
            _quest.CheckAllGoalsCompleted();
        }

    }
}
