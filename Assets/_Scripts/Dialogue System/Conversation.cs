using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Dialogue/Conversation")]
public class Conversation : ScriptableObject
{
    //Array of dialogues
    [SerializeField] public Dialogue[] dialogues;


    //For if we want to expand to allow Dialogue options
    [SerializeField] public Option[] options;
}
