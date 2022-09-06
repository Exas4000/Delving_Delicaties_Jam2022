using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sub_score : Subscriber
{
    public float playerScore = 0;
    [SerializeField] int playerHealth = 3;
    [SerializeField] Text uiScore;
    [SerializeField] Text uiMult;
    [SerializeField] Text uiHp;
    [SerializeField] float[] multiplier;
    [SerializeField] float[] rankThreshold;



    public override void OnScoreEvent(float score)
    {
        playerScore += score;
        UIUpdate();
    }

    public override void OnHealthChangeEvent(int playerHp)
    {
        playerHealth = playerHp;       

        UIHpUpdate();
    }

    public void UIUpdate()
    {
        // uiScore.text = "Score: " + playerScore + "\nFinal Loot Bonus";
        uiScore.text = playerScore + "";

        if (rankThreshold[PlayerPrefs.GetInt("rank")] < playerScore)
        {
            PlayerPrefs.SetInt("rank", PlayerPrefs.GetInt("rank") + 1);
            myObserver.MilestoneEvent();
        }

        uiMult.text = "" + multiplier[PlayerPrefs.GetInt("rank")];
    }

    public void UIHpUpdate()
    {
        uiHp.text = "Health: " + playerHealth;
    }

    public override void OnPlayerDeath()
    {
        base.OnPlayerDeath();

        if (multiplier.Length > 0)
        {
            //PlayerPrefs.SetFloat("DroppedLoot", playerScore * multiplier[PlayerPrefs.GetInt("rank")]);
            PlayerPrefs.SetFloat("DroppedLoot", playerScore * 2);

        }
        else
        {
            PlayerPrefs.SetFloat("DroppedLoot", playerScore);
        }
        
        
    }

    public override void OnPlayerWin()
    {
        base.OnPlayerWin();

        //multiply current score
        playerScore = Mathf.Round(playerScore * multiplier[PlayerPrefs.GetInt("rank")]);
        

        //update UI
        UIUpdate();

        //set new max rank
        if (PlayerPrefs.GetInt("rank") > PlayerPrefs.GetInt("MAXrank"))
        {
            PlayerPrefs.SetInt("MAXrank", PlayerPrefs.GetInt("rank"));
        }
    }
}
