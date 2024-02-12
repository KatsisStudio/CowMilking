using CowMilking.Character.Player;
using CowMilking.SO;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CowMilking.Questing
{
    [CreateAssetMenu(fileName = "New Milking Goal", menuName = "ScriptableObject/Questing/Milking Goal")]
    public class MilkingGoal : Goal
    {
        [SerializeField] private int requiredAmount;
        [SerializeField] private ElementType requiredElement;

        private int currentAmount;

        public override void Initialize(Quest q)
        {
            Debug.Log("Initializing Milking Goal");

            base.Initialize(q);
            currentAmount = 0;

            QuestEvents.OnCowMilked += Increment;
        }

        void Increment(CowInfo cinfo)
        {
            //If ElementType == none, can milk any cow.
            if (requiredElement != ElementType.None && cinfo.Element != requiredElement)
                return;

            currentAmount++;

            if (currentAmount >= requiredAmount)
                Complete();
        }

        public override void Complete()
        {
            QuestEvents.OnCowMilked -= Increment;

            base.Complete();
        }
    }
}