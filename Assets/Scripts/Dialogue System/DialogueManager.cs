using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CowMilking.DialogueSystem
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { private set; get; }


        [SerializeField] private TextMeshProUGUI nameTextLeft;
        [SerializeField] private TextMeshProUGUI nameTextRight;

        [SerializeField] private TMP_Text textTop;
        [SerializeField] private TMP_Text textBottom;

        //Placeholder for a transparent image, used to clear the sprites
        [SerializeField] private Image placeholderTransparent;

        [SerializeField] private Image imageRight;
        [SerializeField] private Image imageLeft;
        [SerializeField] private Image imageFullCG;


        //conversation Queue potentially redundant
        Queue<Conversation> ConversationQueue = new Queue<Conversation>();
        Queue<Dialogue> DialogueQueue = new Queue<Dialogue>();
        Queue<string> SentenceQueue = new Queue<string>();

        //Current Conversation info
        Conversation _currentConversation;
        Dialogue _currentDialogue;
        string _currentSentence;

        bool _typing;

        

        [SerializeField] float _typingSpeed = 0.05f;

        ////TEST CODE
        //public Conversation testConvo;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);

            ClearAllFields();

            _typing = false;

        }

        //private void Start()
        //{
        //    //TEST CODE
        //    StartConversation(testConvo);
        //}

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) { ContinueText(); }
        }

        public void StartConversation(Conversation convo)
        {
            _currentConversation = convo;
            textTop.text = "";
            textBottom.text = "";
            nameTextLeft.text = "";
            nameTextRight.text = "";

            for (int i = 0; i < convo.dialogues.Length; i++)
            {
                DialogueQueue.Enqueue(_currentConversation.dialogues[i]);
            }

            //Setup default images and names on conversation load
            if(_currentConversation.fullCGSpriteDefault != null) { imageFullCG.sprite = _currentConversation.fullCGSpriteDefault; }
            else
            {
                if(_currentConversation.leftSpriteDefault != null)
                {
                    imageLeft.sprite = _currentConversation.leftSpriteDefault;
                    nameTextLeft.text = _currentConversation.leftNameDefault;
                }

                if (_currentConversation.rightSpriteDefault != null)
                {
                    imageRight.sprite = _currentConversation.rightSpriteDefault;
                    nameTextRight.text = _currentConversation.rightNameDefault;
                }
            }

            //Start the first dialogue
            StartNextDialogue(_currentDialogue = DialogueQueue.Dequeue());
        }

        private void StartNextDialogue(Dialogue dialogue)
        {
            for (int i = 0; i < dialogue.sentences.Length; i++)
            {
                SentenceQueue.Enqueue(dialogue.sentences[i]);
            }

            _currentSentence = SentenceQueue.Dequeue();

            if(_currentDialogue.fullScreen)
            {
                imageFullCG.sprite = _currentDialogue.speakerSprite;
            }
            else if(_currentDialogue.onRight)
            {
                imageRight.color = new Color(1, 1, 1, 1);

                nameTextRight.text = _currentDialogue.speakerName;
                imageRight.sprite = _currentDialogue.speakerSprite;

                //Fade non-speaker
                imageLeft.color -= new Color(0, 0, 0, 0.5f);
            }
            else
            {
                imageLeft.color = new Color(1, 1, 1, 1);

                nameTextLeft.text = _currentDialogue.speakerName;
                imageLeft.sprite = _currentDialogue.speakerSprite;

                imageRight.color -= new Color(0, 0, 0, 0.5f);
            }
            

            StartCoroutine(TypeSentence(_currentSentence));
        }

        private IEnumerator TypeSentence(string sentence)
        {
            _typing = true;

            foreach (char c in sentence)
            {
                yield return new WaitForSeconds(_typingSpeed);

                textTop.text += c;
            }

            _typing = false;
        }

        public void ContinueText()
        {
            if (_typing)
            {
                StopAllCoroutines();
                _typing = false;
                textTop.text = _currentSentence;
            }
            else { DisplayNextSentence(); }
        }

        void DisplayNextSentence()
        {
            textTop.text = "";
            textBottom.text = "";

            if (SentenceQueue.Count <= 0)
            {
                if (_currentDialogue.dialogueEvent != null)
                    Instantiate(_currentDialogue.dialogueEvent);

                if (DialogueQueue.Count <= 0)
                {
                    ClearAllFields();
                }
                else
                { StartNextDialogue(_currentDialogue = DialogueQueue.Dequeue()); }
            }
            else { StartCoroutine(TypeSentence(_currentSentence = SentenceQueue.Dequeue())); }
            
        }

        private void ClearAllFields()
        {
            //Initializations
            _currentConversation = null;
            _currentDialogue = null;
            _currentSentence = "";

            //Clear queues
            ConversationQueue.Clear();
            DialogueQueue.Clear();
            SentenceQueue.Clear();

            //Clear textboxes
            textTop.text = "";
            textBottom.text = "";
            nameTextLeft.text = "";
            nameTextRight.text = "";

            imageLeft.sprite = placeholderTransparent.sprite;
            imageRight.sprite = placeholderTransparent.sprite;

            //Call anim to close the dialogue box? Or unload scene?
        }

    }
}
