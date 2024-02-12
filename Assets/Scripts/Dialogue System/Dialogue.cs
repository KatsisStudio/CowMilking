using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CowMilking.DialogueSystem
{
    [System.Serializable]
    public class Dialogue
    {
        //Name of the person currently speaking
        public string speakerName;

        //Sprite of the speaking character
        public Sprite speakerSprite;

        //Check to put this characters sprite on the right side
        //May change to allow for additional locations
        public bool onRight;

        //Checkk for when we need a full screen CG. Overrides onRight in Dialogue Manager
        public bool fullScreen;

        //Array of their in-sequence dialogue
        [TextArea(5, 20)]
        public string[] sentences;

        //Optional event to be triggered when this dialogue completes.
        public GameObject dialogueEvent;
    }
}
