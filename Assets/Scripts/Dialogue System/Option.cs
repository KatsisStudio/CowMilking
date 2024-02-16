using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CowMilking.DialogueSystem
{
    [System.Serializable]
    public class Option
    {
        public string optionText;
        public Conversation conversationPath;

        public void SetupButton(Button btn)
        {
            btn.GetComponentInChildren<TMP_Text>().text = optionText;
        }
    }
}