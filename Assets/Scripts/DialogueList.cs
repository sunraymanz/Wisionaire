using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueList : MonoBehaviour
{
    public int id = 0;
    public Dialogue dialogueResult;

    public Dialogue GetDialogue(int id)
    {
        dialogueResult.name = "Wise Girl"; 
        dialogueResult.sentences = GetSentences(id);
        if (id == 0 || id == 6)
        { dialogueResult.isEndDialogue = true; }
        else { dialogueResult.isEndDialogue = false; }
        return dialogueResult;
    }

    string[] GetSentences(int id)
    {
        string[] temp = new string[] { };
        if (id == 0)
        {
            temp = new string[]
            {
               "Too bad~ maybe you should read more books!",
               "Now please leave! Come back when you are ready!"
            };
        }
        else if (id == 1)
        {
            temp = new string[]
            {
               "Wow~ how smart you are!",
               "But it's not the end! Let's get to next question!"
            };
        }
        else if (id == 2)
        {
            temp = new string[]
               {
               "Oh, Hey Hello! Finally you come. It's time to play game!",
               "This game is like the one you saw on TV.... The questionaire game!" ,
               "The rule is simple : I will ask you 10 question. each question have 4 choice to choose. pick one and see how it's going.",
               "And if you ever watch this kind of game on TV. Yes, You have to answer every question correctly to be winner",
               "If you are wrong. The game stop! and You lose the game! but you won't lose anything else anyway.",
               "Also, If you don't answer the question in 10 second. it consider you lose too.",
               "Anyway, Fear not! If you really don't know what to answer. you can use the helper i gave. There are 3 helper to use",
               "So! Are you ready for the challenge? Let's get to the first question!"
               };
        }
        else if (id == 3)
        {
            temp = new string[]
               {
               "Oh, Did you ask me? You really don't know it? Fine, I'll try.",
               "Hmmm........" ,
               "................" ,
               "........................Ah ha!" ,
               "I don't know it too! hehe >v< too bad~" 
               };
        }
        else if (id == 4)
        {
            temp = new string[]
               {
                "Oh, Did you ask me? You really don't know it? Fine, I'll try.",
               "Hmmm........" ,
               "................" ,
               "........................Ah ha!" ,
               "It's so easy! Here's the answer~" 
               };
        }
        else if (id == 5)
        {
            temp = new string[]
               {
                "Oh, Did you ask me? You really don't know it? Fine, I'll try.",
               "Hmmm........" ,
               "................" ,
               "........................Ah ha!" ,
               "I know it but i won't tell ya! boooo~" 
               };
        }
        else if (id == 6)
        {
            temp = new string[]
               {
                "Amazing!!!~ You can answer it all correctly!",
               "Alright! about time to end this game " ,
               "!!! YOU ARE THE WINNER !!!" 
               };
        }
        return temp;
    }

}

