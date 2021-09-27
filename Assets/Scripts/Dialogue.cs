using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Dialogue
{
    public string name;
    [TextArea(3,5)]
    public string[] sentences;
    public bool isEndDialogue;
    
    public Dialogue(string nameInput,string[] sentencesInput,bool isEnd)
    {
        name = nameInput;
        sentences = sentencesInput;
        isEndDialogue = isEnd;
    }
}


