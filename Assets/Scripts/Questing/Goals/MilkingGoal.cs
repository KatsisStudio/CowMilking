using CowMilking.Character.Player;
using CowMilking.Persistency;
using CowMilking.SO;
using UnityEngine;

namespace CowMilking.Questing
{
    [CreateAssetMenu(fileName = "New Milking Goal", menuName = "ScriptableObject/Questing/Milking Goal")]
    public class MilkingGoal : Goal
    {
        public override void Initialize(Quest q, int id)
        {
            Debug.Log("Initializing Milking Goal");

            base.Initialize(q, id);

            if (PersistencyManager.Instance.SaveData.GetQuestProgress(quest.questID, goalID) >= requiredAmount)
            {
                completed = true;
            }
                
            else
                QuestEvents.OnCowMilked += Increment;
        }

        void Increment(CowInfo cinfo)
        {
            //If ElementType == none, can milk any cow.
            if (requiredElement != ElementType.None  && cinfo.Element != requiredElement)
                return;

            PersistencyManager.Instance.SaveData.UpdateQuestProgress(quest.questID, goalID);

            if (PersistencyManager.Instance.SaveData.GetQuestProgress(quest.questID, goalID) >= requiredAmount)
                Complete();
        }

        public override void Complete()
        {
            QuestEvents.OnCowMilked -= Increment;

            base.Complete();
        }

        public override void ResetGoal()
        {
            base.ResetGoal();
            PersistencyManager.Instance.SaveData.ResetQuestProgress(quest.questID, goalID);
        }
    }
}