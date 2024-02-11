using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "ScriptableObject/Dialogue/Conversation")]
public class Conversation : ScriptableObject
{
    //Array of dialogues
    public Dialogue[] dialogues;


    //For if we want to expand to allow Dialogue options
    public Option[] options;
}
