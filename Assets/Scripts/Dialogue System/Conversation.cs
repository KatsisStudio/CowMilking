using UnityEngine;

namespace CowMilking.DialogueSystem
{
    [CreateAssetMenu(fileName = "New Conversation", menuName = "ScriptableObject/Dialogue/Conversation")]
    public class Conversation : ScriptableObject
    {
        public string leftNameDefault;
        public string rightNameDefault;

        public Sprite leftSpriteDefault;
        public Sprite rightSpriteDefault;
        public Sprite fullCGSpriteDefault;

        //Array of dialogues
        public Dialogue[] dialogues;
    }
}