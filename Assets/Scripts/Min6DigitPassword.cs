using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Min6DigitPassword : Minigame
{
    bool isComplete;
    int length = 0;

    string password = "0123";

    string input = "";

    public override async Task<int> completeCondition(CancellationToken token)
    {
        Debug.Log("Começouuuuuuu");
        int score = 500;
        while(!isComplete)
        {
            await Task.Yield();
            if(token.IsCancellationRequested) {
                score = -100;
                break;
            }
        }
        return score;
    }

    public override bool getComplete()
    {
        return isComplete;
    }

    public void addNumber(string val)
    {
        input = input.Insert(input.Length, val);
        Debug.Log(input + " " + input.Length);
        transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Text>().text = input;
        if(input.Length != 4) return;
        if(input.Equals(password)) {isComplete = true;}
        else {input = "";
        Debug.Log("WRONG BITCH");
        }
    }
}
