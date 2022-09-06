using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonShooter : MonoBehaviour
{
    [SerializeField] GameObject boomRang; //projectile
    private GameObject player;
    [SerializeField] float range = 12; // reach for the attack
    [SerializeField] float postAttackDelay = 3;
    private float postAttackCooldown = 0;
    private Vector2 direction = new Vector2(0, 0);


    [SerializeField] AudioSource mySound;

    [SerializeField] bool canLook = false;
    [SerializeField] Sprite[] look;
    [SerializeField] SpriteRenderer myRender;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

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
        if (boomRang != null && postAttackCooldown <= 0)
        {
            if (Vector2.Distance(transform.position, player.transform.position) <= range)
            {
                //play animation
               

                postAttackCooldown = postAttackDelay;

                var boom = Instantiate(boomRang, transform.position, Quaternion.identity);

                audioFunction(true);
            }
        }

        if (postAttackCooldown > 0)
        {
            postAttackCooldown -= Time.deltaTime;
        }

        if (canLook && myRender != null)
        {
            float playerX = player.transform.position.x - transform.position.x;
            float playerY = player.transform.position.y - transform.position.y;

            if (Mathf.Abs(playerX) > Mathf.Abs(playerY))
            {
                if (playerX > 0)
                {
                    myRender.sprite = look[0];
                }
                else
                {
                    myRender.sprite = look[1];
                }
            }
            else
            {
                if (playerY > 0)
                {
                    myRender.sprite = look[2];
                }
                else
                {
                    myRender.sprite = look[3];
                }
            }

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
        mySound.volume = PlayerPrefs.GetFloat("Volume_Sound");
    }
}
