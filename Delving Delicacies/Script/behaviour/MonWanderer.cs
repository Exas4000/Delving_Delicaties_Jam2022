using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonWanderer : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float directionChangeDelay = 3;
    private float cooldown = 0;
    private Vector2 direction = new Vector2(0, 0);

    private Rigidbody2D myRB;
    [SerializeField] Anim_struct myAnim;

    [SerializeField] AudioSource mySound;
    [SerializeField] float soundDelay = 0.2f;
    private float soundCooldown = 0;
    private bool pitch = true;


    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        decideDirection();

        if (mySound == null)
        {
            mySound = GetComponent<AudioSource>();           
        }

        if (mySound != null)
        {
            adjustVolume();
        }
    }


    void Update()
    {
        myRB.AddForce( new Vector2(direction.x, direction.y)* speed * Time.deltaTime);

        if (myAnim != null)
        {
            myAnim.PassDirectionVector(direction);
        }

        if (cooldown <= 0)
        {
            decideDirection();
        }
        else
        {
            cooldown -= Time.deltaTime;
        }

        if (soundCooldown <= 0 )
        {
            audioFunction(pitch);
            pitch = !pitch;
            soundCooldown = soundDelay;
        }
        else
        {
            soundCooldown -= Time.deltaTime;
        }
    }


    private void decideDirection()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        cooldown = directionChangeDelay;
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
        mySound.volume = PlayerPrefs.GetFloat("Volume_Sound");
    }
}
