using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] public Queue<string> sentencesQueue;
    public int num;
    public Dialogue dialogue;
    public DialogueList dialogueList;
    public Text nameUI;
    public Text sentencesUI;
    [SerializeField] GameObject npc;
    [SerializeField] GameObject dialogueUI;
    [SerializeField] GameObject winCover;
    [SerializeField] GameObject loseCover;
    [SerializeField] GameObject questionUI;

    void Start()
    {
        sentencesQueue = new Queue<string>();
        dialogueList = new DialogueList();
    }
   
    /*public void StartDialogue(Dialogue dialogue)
    {
        
        Debug.Log("Starting Conversation : "+dialogue.name);
        foreach (string sentence in dialogue.sentences)
        {
            sentencesQueue.Enqueue(sentence);
        }
        DisplayNextSentence();
    }*/

    public bool StartDialogue(int id)
    {
        npc.SetActive(true);
        dialogueUI.SetActive(true);
        questionUI.SetActive(false);
        FindObjectOfType<Gameplay>().isActive = false;
        sentencesQueue.Clear();
        num = id;
        dialogue = dialogueList.GetDialogue(id);
        Debug.Log("Starting Conversation : " + dialogue.name);
        nameUI.text = dialogue.name;
        foreach (string sentence in dialogue.sentences)
        {
            sentencesQueue.Enqueue(sentence);
        }
        DisplayNextSentence();
        return true;
    }

    public bool DisplayNextSentence()
    {
        if (sentencesQueue.Count > 0)
        {
            string sentence = sentencesQueue.Dequeue();
            Debug.Log(sentence);
            sentencesUI.text = sentence;
            return false;
        }
        else
        { 
            EndDialogue();
            return true;
        }
    }

    private void EndDialogue()
    {
        npc.SetActive(false);
        dialogueUI.SetActive(false);
        questionUI.SetActive(true);
        FindObjectOfType<Gameplay>().isActive=true;
        sentencesQueue.Clear();
        Debug.Log("End Conversation");
        if (dialogue.isEndDialogue)
        {
            if (num == 0)
            {
                loseCover.SetActive(true);
            }
            FindObjectOfType<GameManager>().DelayRestartGame(2f);
        }
    }

    
}
