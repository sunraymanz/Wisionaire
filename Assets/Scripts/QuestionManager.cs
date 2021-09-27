using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public Question question;
    public DialogueTrigger triggerToken;
    [SerializeField] public List<Question> questionToken;
    public int questionSelect;
    public int current = 0;
    public Text questionUI;
    public Text answer1UI;
    public Text answer2UI;
    public Text answer3UI;
    public Text answer4UI;
    [SerializeField] GameObject winCover;

    // Start is called before the first frame update
    void Start()
    {
        questionToken = FindObjectOfType<QuestionList>().questionList;
        triggerToken = FindObjectOfType<DialogueTrigger>();
    }

    
    public void LoadNextQuestion()
    {
        if (questionToken.Count > 0)
        {
            questionSelect = Random.Range(0, questionToken.Count);
            question = questionToken[questionSelect];
            current++;
            questionToken.RemoveAt(questionSelect);
            Debug.Log("Question : "+ current + "/10");
            DisplayQuestion();
        }
        else 
        {
            Debug.Log("Out of Question");
            triggerToken.TriggerWinDialogue();
            //winCover.SetActive(true);
            //FindObjectOfType<GameManager>().DelayRestartGame(2f);
        }
        
    }
    public void DisplayQuestion()
    {
        questionUI.text = current+"."+question.questionText;
        answer1UI.text = "1."+question.answerText[0];
        answer2UI.text = "2."+question.answerText[1];
        answer3UI.text = "3."+question.answerText[2];
        answer4UI.text = "4."+question.answerText[3];
    }
    public void DisableChoice(int i) 
    {
        if (i == 1) 
        { answer1UI.GetComponentInParent<Button>().interactable = false; }
        else if (i == 2)
        { answer2UI.GetComponentInParent<Button>().interactable = false; }
        else if (i == 3)
        { answer3UI.GetComponentInParent<Button>().interactable = false; }
        else { answer4UI.GetComponentInParent<Button>().interactable = false; }
    }
    public void SubmitAnswer(int input)
    {
        FindObjectOfType<Gameplay>().initiateUI();
        if (input == question.answer)
        { ResultCorrect(); }
        else
        { ResultWrong(); }
    }

    void ResultCorrect()
    {
        triggerToken.TriggerCorrectDialogue();
        LoadNextQuestion();
    }

    void ResultWrong()
    {
        triggerToken.TriggerWrongDialogue();
    }
}
