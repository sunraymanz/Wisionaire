using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    public Slider timerBar;
    public QuestionManager questionToken;
    public DialogueTrigger triggerToken;
    float currentTime = 0;
    float maxTime = 10;
    public bool isActive = true;
    public Button helper1;
    public Button helper2;
    public Button helper3;
    public Button answer1;
    public Button answer2;
    public Button answer3;
    public Button answer4;


    // Start is called before the first frame update
    void Start()
    {
        initiateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        { currentTime += Time.deltaTime;}
        RefreshUI();
        CheckTime();
    }

    void RefreshUI()
    {
        timerBar.value = currentTime;
    }
    public void initiateUI()
    {
        currentTime = 0;
        maxTime = 10;
        timerBar.value = 0;
        timerBar.maxValue = 10;
        answer1.interactable = true;
        answer2.interactable = true;
        answer3.interactable = true;
        answer4.interactable = true;
    }

    void CheckTime()
    {
        if (currentTime > maxTime)
        { 
            questionToken.SubmitAnswer(0);
            initiateUI();
        }
    }
    public void DoubleTime()
    {
        helper1.interactable = false;
        maxTime *= 2;
        timerBar.maxValue = maxTime;
    }
    public void CutTheChoice()
    {
        helper2.interactable = false;
        int answer = questionToken.question.answer;
        int random1 ;
        int random2 ;
        do
        {
            random1 = Random.Range(1, 5);
        } while (random1 == answer);
        Debug.Log("Cut the "+ random1 +" Choice");
        questionToken.DisableChoice(random1);
        do
        {
            random2 = Random.Range(1, 5);
        } while (random2 == answer || random2 == random1);
        Debug.Log("Cut the " + random2 + " Choice");
        questionToken.DisableChoice(random2);
    }

    public void AskZenny()
    {
        helper3.interactable = false;
        int temp = Random.Range(1,6);
        //int temp = 3;
        Debug.Log("Ask Value : " + temp);
        if (temp == 1)
        {
            //Don't know
            triggerToken.TriggerDialogue(3);
        }
        else if (temp < 4)
        {
            //Reveal Answer
            RevealAnswer();
            triggerToken.TriggerDialogue(4);
        }
        else 
        {
            //Not Help
            triggerToken.TriggerDialogue(5);
        }
    }
    public void RevealAnswer()
    {
        int answer = questionToken.question.answer;
        int[] answerList = { 1, 2, 3, 4 };
        foreach (int item in answerList)
        {
            if (item != answer)
            {
                Debug.Log("Cut the " + item + " Choice");
                questionToken.DisableChoice(item);
            }
        }
    }
}
