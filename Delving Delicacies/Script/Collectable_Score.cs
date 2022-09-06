using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable_Score : MonoBehaviour
{
    [SerializeField] float myValue = 10;
    [SerializeField] public Observer myObserver;
    [SerializeField] AudioSource mySound;


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

        if (mySound != null)
        {
            mySound.volume = PlayerPrefs.GetFloat("Volume_Sound");
            mySound.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //when a player overlap with me, cause a score event equal to my own value, then self destroy
            myObserver.ScoreEvent(myValue);
            Destroy(this.gameObject);           
        }
    }

    public void setValue(float newValue)
    {
        myValue = newValue;
    }

    public float getValue()
    {
        return myValue;
    }


}
