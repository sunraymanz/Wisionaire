using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] bool isStart = false;
    [SerializeField] bool isEnd = false;
    [SerializeField] QuestionManager questionToken;
    public int stage = 2;
    //public Dialogue dialogue;
    private void Start()
    {
        TriggerStartDialogue();
        isStart = true;
        questionToken = FindObjectOfType<QuestionManager>();
    }
    public void Update()
    {
        TestKeyPress();
    }

    //Dialogue Zone

    public void TestKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            questionToken.LoadNextQuestion();
        }
        if (!isStart)
        {
            isEnd = false;
            if (Input.GetKeyDown(KeyCode.Return))
            {
                TriggerStartDialogue();
            }
            else if (Input.GetKeyDown(KeyCode.Y))
            {
                TriggerCorrectDialogue();
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                TriggerWrongDialogue();
            }
        }

        else if (Input.anyKeyDown)
        {
            TriggerNextDialogue();
        }
    }
    public void TriggerStartDialogue()
    {
        isStart = FindObjectOfType<DialogueManager>().StartDialogue(stage);
    }
    public void TriggerDialogue(int id)
    {
        isStart = FindObjectOfType<DialogueManager>().StartDialogue(id);
    }
    public void TriggerCorrectDialogue()
    {
        isStart = FindObjectOfType<DialogueManager>().StartDialogue(1);
    }
    public void TriggerWrongDialogue()
    {
        isStart = FindObjectOfType<DialogueManager>().StartDialogue(0);
    }
    public void TriggerWinDialogue()
    {
        isStart = FindObjectOfType<DialogueManager>().StartDialogue(6);
    }

    public void TriggerNextDialogue()
    {
        isEnd = FindObjectOfType<DialogueManager>().DisplayNextSentence();
        if (isEnd)
        { 
            isStart = false;
            if (stage == 2)
            { stage++; questionToken.LoadNextQuestion(); }
        }
    }
}
