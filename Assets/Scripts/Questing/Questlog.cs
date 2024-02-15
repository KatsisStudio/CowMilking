using CowMilking.Questing;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CowMilking.Questing
{
    public class Questlog : MonoBehaviour
    {
        public List<Quest> listOfQuests;

        [SerializeField] private Transform contentZone;

        
        [SerializeField] private QuestListObject questListObjectRef;

        //For QuestInfo
        [SerializeField] private GameObject questInfoPanel;
        public TMP_Text questInfoName;
        public TMP_Text questInfoDescription;
        public TMP_Text questInfoGoals;
        public TMP_Text questInfoRewards;

        int yOffset = -10;
        int questCounter = 0;

        private void Start()
        {

            foreach (Quest q in listOfQuests)
            {
                GameObject lObject = Instantiate(questListObjectRef.listObject, contentZone);
                QuestListObject qlObject = lObject.GetComponent<QuestListObject>();

                qlObject.quest = q;

                qlObject.nameText.text = q.questName;

                if (q.questComplete)
                    qlObject.statusText.text = "Completed";
                else
                    qlObject.statusText.text = "In Progress";

                lObject.GetComponent<RectTransform>().localPosition = new Vector2(lObject.GetComponent<RectTransform>().localPosition.x, -100 * questCounter + yOffset);

                questCounter++;

                lObject.SetActive(true);
            }
        }

        public void EnableQuestInfoPanel(Quest q)
        {
            questInfoRewards.text = "";
            questInfoGoals.text = "";

            questInfoPanel.SetActive(true);
            questInfoName.text = q.questName;
            questInfoDescription.text = q.GetQuestDescription();

            foreach(Goal g in q.goals)
            {
                questInfoGoals.text += g.goalSummary + " --- " + g.currentAmount.ToString() + "/" + g.requiredAmount + "\n";
            }

            foreach (Quest.QuestRewards qr in q.questRewards)
            {
                questInfoRewards.text += qr.reward.ToString() + " x" + qr.amount.ToString() + "\n";
            }
        }

        public void ExitClick()
        {
            if (questInfoPanel.activeSelf)
                questInfoPanel.SetActive(false);
            else
            {
                //close the Questlog
            }
        }
    }
}