using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Option", menuName = "Dialogue/Option")]
public class Option : MonoBehaviour
{
    [SerializeField] public string optionText;
    [SerializeField] public Conversation leadsIntoConversation;
}
