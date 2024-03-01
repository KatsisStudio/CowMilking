using UnityEngine;

namespace CowMilking.DialogueSystem
{
    public class ConversationEvent : MonoBehaviour
    {
        // Start is called before the first frame update
        public virtual void OnEnable()
        {
            TriggerEvent();
        }

        public virtual void TriggerEvent()
        {
            //Call this at the end of the event to destroy the object

            Destroy(this.gameObject);
        }
    }
}