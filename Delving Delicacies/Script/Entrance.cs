using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrance : MonoBehaviour
{
    [SerializeField] public Observer myObserver;
    [SerializeField] int jokeSceneID;


    private float hardTimer = 5f;
    private bool active = false;
    private bool winOnce = false;

    void Start()
    {
        if (myObserver == null)
        {
            GameObject tempObs = GameObject.FindGameObjectsWithTag("Observer")[0];

            if (tempObs != null)
            {
                myObserver = tempObs.GetComponent<Observer>();
            }
        }
    }

    void Update()
    {
        if (hardTimer > 0)
        {
            hardTimer -= Time.deltaTime;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !active && hardTimer <= 0 && PlayerPrefs.GetInt("rank") >= 2)
        {
            if (!winOnce)
            {
                myObserver.WinEvent();
                winOnce = true;
            }
            
        }
        else if ((hardTimer > 0 || PlayerPrefs.GetInt("rank") < 2) && collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(jokeSceneID);
        }
        
    }

}
