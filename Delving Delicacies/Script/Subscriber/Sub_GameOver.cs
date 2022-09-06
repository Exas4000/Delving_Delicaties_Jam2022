using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sub_GameOver : Subscriber
{
    private bool hasActivate = false;
    [SerializeField] GameObject[] GameOver;
    [SerializeField] GameObject[] reset;
    [SerializeField] GameObject[] win;

    public override void OnPlayerDeath()
    {
        base.OnPlayerDeath();
        if (!hasActivate)
        {

            if (PlayerPrefs.GetInt("Death") >= 5)
            {
                for (int i = 0; i < GameOver.Length; i++)
                {
                    GameOver[i].SetActive(true);
                    myObserver.CallCutscene(true);
                }
            }
            else
            {
                //should code to simulate a blackout before a reset
                for (int i = 0; i < reset.Length; i++)
                {
                    reset[i].SetActive(true);
                    myObserver.CallCutscene(true);
                }
            }
            
        }
    }

    public void ChangeScene(int sceneID)
    {
        

        if (PlayerPrefs.GetInt("rank")  > PlayerPrefs.GetInt("MAXrank"))
        {
            PlayerPrefs.SetInt("MAXrank", PlayerPrefs.GetInt("rank"));
        }

        SceneManager.LoadScene(sceneID);
    }

    public void ChangeSceneWin()
    {
        

        if (PlayerPrefs.GetInt("rank") > PlayerPrefs.GetInt("MAXrank"))
        {
            PlayerPrefs.SetInt("MAXrank", PlayerPrefs.GetInt("rank"));
        }

        if (PlayerPrefs.GetInt("rank") >= 5)
        {
            SceneManager.LoadScene(8);
        }
        else if (PlayerPrefs.GetInt("rank") >= 4)
        {
            SceneManager.LoadScene(7);
        }
        else if (PlayerPrefs.GetInt("rank") >= 3)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            SceneManager.LoadScene(3);
        }


    }

    public override void OnPlayerWin()
    {
        base.OnPlayerWin();

        for (int i = 0; i < win.Length; i++)
        {
            win[i].SetActive(true);
            myObserver.CallCutscene(true);
        }
    }

}
