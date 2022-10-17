using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager instance;

    public TextMeshProUGUI nameText;

    public string characterName;

    public TextMeshProUGUI dialogueText;
    //keeps track of descendants 
    private Queue<string> sentences; //FIFO - better format for dialogue

    private void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue){
        Debug.Log("Starting convo with " + dialogue.name);
        characterName = dialogue.name;
        nameText.text = dialogue.name;

        sentences.Clear();
        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    void EndDialogue(){
        Debug.Log("End convo");
    }
}
