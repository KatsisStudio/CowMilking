using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;


    [SerializeField] private TextMeshProUGUI TXT_nameLeft;
    [SerializeField] private TextMeshProUGUI TXT_nameRight;

    [SerializeField] private TextMeshProUGUI TXT_dialogueTop;
    [SerializeField] private TextMeshProUGUI TXT_dialogueBottom;

    [SerializeField] private Image IMG_spriteLeft;
    [SerializeField] private Image IMG_spriteRight;


    bool _typing;


    //conversation Queue potentialls redundant
    Queue<Conversation> ConversationQueue = new Queue<Conversation>();
    Queue<Dialogue> DialogueQueue = new Queue<Dialogue>();
    Queue<string> SentenceQueue = new Queue<string>();

    //Current Conversation info
    Conversation _currentConversation;
    Dialogue _currentDialogue;
    string _currentSentence;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        //Initializations
        _currentConversation = null;
        _currentDialogue = null;
        _currentSentence = "";
        
        //Clear queues
        ConversationQueue.Clear();
        DialogueQueue.Clear();
        SentenceQueue.Clear();

        //Clear textboxes
        TXT_dialogueTop.text = "";
        TXT_dialogueBottom.text = "";
        TXT_nameLeft.text = "";
        TXT_nameRight.text = "";

        _typing = false;

    }

    public void StartConversation(Conversation convo)
    {
        _currentConversation = convo;
        TXT_dialogueTop.text = "";
        TXT_dialogueBottom.text = "";
        TXT_nameLeft.text = "";
        TXT_nameRight.text = "";

        for (int i = 0; i < convo.dialogues.Length; i++)
        {
            DialogueQueue.Enqueue(_currentConversation.dialogues[i]);
        }

        //Start the first dialogue
        StartNextDialogue(_currentDialogue = DialogueQueue.Dequeue());
    }

    private void StartNextDialogue(Dialogue dialogue)
    {
        for(int i = 0; i < dialogue.sentences.Length; i++)
        {
            SentenceQueue.Enqueue(dialogue.sentences[i]);
        }

        _currentSentence = SentenceQueue.Dequeue();

        TXT_nameLeft.text = _currentDialogue.speakerName;
        IMG_spriteLeft.sprite = _currentDialogue.speakerSprite;
    }

}
