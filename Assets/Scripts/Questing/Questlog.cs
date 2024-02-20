using CowMilking.Persistency;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CowMilking.Questing
{
    public class Questlog : MonoBehaviour
    {
        public static Questlog Instance { private set; get; }

        public static bool QuestsInitialized = false;

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

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            foreach (Quest q in listOfQuests)
            {
                //BUG: each time the farm is loaded, all quests are initialized as new versions of the same quest
                //This increases the number of calls to a specific quest, messing up progression
                if(!QuestsInitialized)
                    q.Initialize();

                GameObject lObject = Instantiate(questListObjectRef.listObject, contentZone);
                QuestListObject qlObject = lObject.GetComponent<QuestListObject>();

                qlObject.quest = q;

                qlObject.nameText.text = q.questName;

                qlObject.statusText.text = "Completons: " + PersistencyManager.Instance.SaveData.GetQuestCompletionCount(q.questID).ToString();

                lObject.GetComponent<RectTransform>().localPosition = new Vector2(lObject.GetComponent<RectTransform>().localPosition.x, -100 * questCounter + yOffset);

                questCounter++;

                lObject.SetActive(true);
            }

            QuestsInitialized = true;

            this.gameObject.SetActive(false);
            questInfoPanel.SetActive(false);
        }

        public void EnableQuestInfoPanel(Quest q)
        {
            questInfoRewards.text = "";
            questInfoGoals.text = "";

            questInfoPanel.SetActive(true);
            questInfoName.text = q.questName;
            questInfoDescription.text = q.GetQuestDescription();

            for (int i = 0; i < q.goals.Length; i++)
            {
                var g = q.goals[i];
                var amount = PersistencyManager.Instance.SaveData.GetQuestProgress(q.questID, g.goalID);

                questInfoGoals.text += g.goalSummary + " --- " + amount.ToString() + "/" + g.requiredAmount + "\n";
            }

            foreach (Quest.QuestRewards qr in q.questRewards)
            {
                questInfoRewards.text += qr.reward.ToString() + " x" + qr.amount.ToString() + "\n";
            }
        }

        public void ExitClick()
        {
            if (questInfoPanel.activeInHierarchy)
                questInfoPanel.SetActive(false);
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}