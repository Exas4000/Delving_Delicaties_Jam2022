using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatingBehaviour : MonoBehaviour
{

    //used for continuous damage
    [SerializeField] int damage = 1;
    [SerializeField] bool isFriendlyFire = true;
    [SerializeField] bool hurtEnemy = true;

    [SerializeField] bool isActive = false; 
    [SerializeField] float trapDelay = 5;

    [SerializeField] Sprite activeSprite;
    [SerializeField] Sprite disableSprite;

    private float cooldown = 0;
    private AudioSource mySound;

    void Start()
    {
        cooldown = trapDelay;
        changeColour(isActive); //visual testing code
        ChangeVisual(isActive);

        mySound = GetComponent<AudioSource>();
        adjustVolume();
    }

    // Update is called once per frame
    void Update()
    {
        //every few moments, enable/disable contact damage
        if (cooldown <=0)
        {
            isActive = !isActive;
            cooldown = trapDelay;
            // visual code
            changeColour(isActive);
            ChangeVisual(isActive);
            audioFunction(isActive);
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (isActive)
        {
            if (collision.tag == "Player" && isFriendlyFire)
            {
                collision.gameObject.GetComponent<PlayerHp>().HurtPlayerHp(damage);
            }

            if (collision.tag == "Enemy" && hurtEnemy)
            {
                //change this for hp script on the enemy
                collision.gameObject.GetComponent<MonHP>().HurtMonsterHp(damage);
            }
        }

        
    }

    private void changeColour(bool color)
    {
        if (color)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
        
    }

    private void ChangeVisual(bool Active)
    {
        if (Active && activeSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = activeSprite;
        }
        else if (disableSprite != null)
        {
            GetComponent<SpriteRenderer>().sprite = disableSprite;
        }
    }

    private void audioFunction(bool pitch)
    {
        if (pitch)
        {
            mySound.pitch = 1;
        }
        else
        {
            mySound.pitch = 0.5f;
        }

        mySound.Play();
    }

    private void adjustVolume()
    {
        mySound.volume = PlayerPrefs.GetFloat("Volume_Sound") /2;
    }
}
