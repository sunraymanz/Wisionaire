using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionList : MonoBehaviour
{
    public int id = 0;
    //public Question questionResult;
    public List<Question> questionList;

    void Start() 
    {
        for (int count = 0; count < 10; count++)
        {
            questionList.Add(GetQuestion(count));
        }
    }

    public Question GetQuestion(int id)
    {
        Question questionResult = new Question();
        questionResult.question = id+1;
        questionResult.questionText = GetQuestionText(id);
        questionResult.answerText = GetAnswerText(id);
        questionResult.answer = GetAnswer(id);
        return questionResult;
    }

    string GetQuestionText(int id)
    {
        string temp = "";
        if (id == 0)
        {
            temp = "Which vegetable gives Popeye his strength?";
        }
        else if (id == 1)
        {
            temp = "Who was the ancient Greek goddess of love and beauty?";
        }
        else if (id == 2)
        {
            temp = "Which alcoholic drink is made from the leaves of the agave plant and gets its name from an area around a Mexican city?";
        }
        else if (id == 3)
        {
            temp = "What does the Q in IQ stand for?";
        }
        else if (id == 4)
        {
            temp = "What is the name of Superman’s home planet?";
        }
        else if (id == 5)
        {
            temp = "According to legend, kissing which stone in Ireland gives you the gift of the gab?";
        }
        else if (id == 6)
        {
            temp = "In which U.S. city is NASA’s Mission Control Center located?";
        }
        else if (id == 7)
        {
            temp = "What is the Latin word for “beyond”, often used as a prefix to signify an extreme?";
        }
        else if (id == 8)
        {
            temp = "Bronze is mainly an alloy of tin and which other metal?";
        }
        else if (id == 9)
        {
            temp = "In meteorology, what name is given to a line of equal pressure on a map?";
        }
        return temp;
    }
    string[] GetAnswerText(int id)
    {
        string[] temp = new string[] { };
        if (id == 0)
        {
            temp = new string[]
            {
               "Broccoli.",
               "Spinach.",
               "Asparagus.",
               "Lentils."
            };
        }
        else if (id == 1)
        {
            temp = new string[]
            {
               "Aphrodite.",
               "Calliope.",
               "Athena.",
               "Calypso."
            };
        }
        else if (id == 2)
        {
            temp = new string[]
            {
               "Tequila.",
               "Singani.",
               "Chicha.",
               "Kasiri."
            };
        }
        else if (id == 3)
        {
            temp = new string[]
            {
               "Quantity.",
               "Quorum.",
               "Quality.",
               "Quotient."
            };
        }
        else if (id == 4)
        {
            temp = new string[]
            {
               "Argon.",
               "Rann.",
               "Krypton.",
               "Qward."
            };
        }
        else if (id == 5)
        {
            temp = new string[]
            {
               "The Blarney Stone.",
               "The Baloney Stone.",
               "The Rosetta Stone.",
               "The Stone of Destiny."
            };
        }
        else if (id == 6)
        {
            temp = new string[]
            {
               "Huntsville, Alabama.",
               "Houston, Texas.",
               "Hampton, Virginia.",
               "Cape Canaveral, Florida."
            };
        }
        else if (id == 7)
        {
            temp = new string[]
            {
               "Extra.",
               "Super.",
               "Ultra.",
               "Mega."
            };
        }
        else if (id == 8)
        {
            temp = new string[]
            {
               "Brass.",
               "Lead.",
               "Iron.",
               "Copper."
            };
        }
        else if (id == 9)
        {
            temp = new string[]
            {
               "Isotherm.",
               "Isobar.",
               "Isochor.",
               "Isoquant."
            };
        }
        return temp;
    }

    int GetAnswer(int id)
    {
        if (id == 0)
        {
            return 2;
        }
        else if (id == 1)
        {
            return 1;
        }
        else if (id == 2)
        {
            return 1;
        }
        else if (id == 3)
        {
            return 4;
        }
        else if (id == 4)
        {
            return 3;
        }
        else if (id == 5)
        {
            return 1;
        }
        else if (id == 6)
        {
            return 2;
        }
        else if (id == 7)
        {
            return 3;
        }
        else if (id == 8)
        {
            return 4;
        }
        else { return 2; }

    }
}
