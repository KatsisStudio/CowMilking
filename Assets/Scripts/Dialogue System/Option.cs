using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Option", menuName = "ScriptableObject/Dialogue/Option")]
public class Option : ScriptableObject
{
    public string optionText;
    public Conversation leadsIntoConversation;
}
