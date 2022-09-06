using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] int MaxplayerHp = 3;
    private int playerHp;

    [SerializeField] float invincibilityTime = 1;
    private float invinTimer = 0;

    [SerializeField] public Observer myObserver;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        playerHp = MaxplayerHp;

        if (myObserver == null)
        {
            GameObject tempObs = GameObject.FindGameObjectsWithTag("Observer")[0];

            if (tempObs != null)
            {
                myObserver = tempObs.GetComponent<Observer>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (invinTimer > 0)
        {
            invinTimer -= Time.deltaTime;
        }
    }

    public void SetPlayerHp(int newValue)
    {
        playerHp = newValue;
    }

    public int GetPlayerHp()
    {
        return playerHp;
    }

    public void HurtPlayerHp(int value)
    {


        if (invinTimer <= 0)
        {
            Debug.Log("hurt player!");
            //if not during invincibility frames, hurt and set invulnerability
            playerHp -= value;
            invinTimer = invincibilityTime;
            //call observer for player hurt
            myObserver.PlayerHealthChange(playerHp);
        }
       

        if (playerHp > MaxplayerHp)
        {
            playerHp = MaxplayerHp;
        }

        if (playerHp <= 0 && !dead)
        {
            dead = true;
            playerHp = 0;
            myObserver.PlayerHealthChange(playerHp);
            //call observer for player death
            PlayerPrefs.SetFloat("DeathX", transform.position.x);
            PlayerPrefs.SetFloat("DeathY", transform.position.y);
            PlayerPrefs.SetInt("Death", PlayerPrefs.GetInt("Death") + 1);
            myObserver.PlayerDeath();
        }

    }
}
