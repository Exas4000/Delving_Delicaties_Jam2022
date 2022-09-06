using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeRelic : MonoBehaviour
{
    [SerializeField] public Observer myObserver;
    [SerializeField] float scoreValue = 1000;

    [SerializeField] GameObject enemyGuardian;

    

    
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //observer events
            myObserver.ScoreEvent(scoreValue);
            //relic collected event?


            //enable guardian
            enemyGuardian.SetActive(true);

            Destroy(this.gameObject);

        }
    }
}
