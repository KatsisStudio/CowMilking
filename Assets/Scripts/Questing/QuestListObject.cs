using CowMilking.Questing;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CowMilking.Questing
{
    public class QuestListObject : MonoBehaviour
    {
        public Questlog questLog;

        public GameObject listObject;

        public TMP_Text nameText;
        public TMP_Text statusText;
        public Quest quest;

        public void OnClicked()
        {
            questLog.EnableQuestInfoPanel(quest);
        }
    }
}