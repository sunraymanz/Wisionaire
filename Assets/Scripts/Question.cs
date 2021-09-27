using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public int question;
    public int answer;

    [TextArea(3, 5)]
    public string questionText;

    [TextArea(1,2)]
    public string[] answerText;

}
