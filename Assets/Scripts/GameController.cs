using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Action[] actions;
    public Player player;
    public Text historyText;
    public Text currText;
    public InputField inputText;
    [TextArea]
    public string introText;

    
    private void Start() {
        historyText.text = introText;
        displayLoc();
        inputText.ActivateInputField();
    }

    public void displayLoc(bool additive = false)
    {
        string desc = player.currLocation.Description+"\n";
        desc+=player.currLocation.getConDesc();
        desc+= player.currLocation.getItemText();
        if(additive)
        {
            currText.text =currText.text+" \n" + desc;
        }
        else
            currText.text = desc;
    }

    public void textEntered()
    {
        logCurrText();
        processInput(inputText.text);
        inputText.text = "";
        inputText.ActivateInputField();

    } 

    void logCurrText()
    {
        historyText.text +="\n\n";
        historyText.text += currText.text;
        historyText.text += "\n\n";
        historyText.text += "<color=#aaccaaff>"+ inputText.text + "</color>";
    }

    void processInput(string input)
    {
        input = input.ToLower();
        char[] delemiter = {' '};
        string[] seperatedWords = input.Split(delemiter);
        //process these commands
        foreach (Action action in actions)
        {
            if(action.keyword.ToLower() == seperatedWords[0])
            {
                if(seperatedWords.Length > 1)
                action.processInput(this,seperatedWords[1]);
                else
                action.processInput(this,"");

                return;
            }
        }
        currText.text = "Nothing Happens!(Having trouble? type help)";
    }
}
