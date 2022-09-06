using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangSpawner : MonoBehaviour
{

    [SerializeField] GameObject boomRang; //projectile
    private GameObject player;
    [SerializeField] float range = 4; // reach for the attack
    [SerializeField] float postAttackDelay = 3;
    [SerializeField] bool disableBehav = false; //set to true if the monobehaviour array is not empty
    private float postAttackCooldown = 0;
    private Vector2 direction = new Vector2(0, 0);

    private bool isAttacking = false;

    [SerializeField] MonoBehaviour[] behaviourDisable;
    [SerializeField] GameObject head;

    [SerializeField] AudioSource mySound;


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

    // Update is called once per frame
    void Update()
    {
        if (head != null)
        {
            head.SetActive(!isAttacking);
        }

        if (boomRang != null && !isAttacking && postAttackCooldown <= 0)
        {
            if (Vector2.Distance(transform.position, player.transform.position) <= range)
            {
                //play animation

                if (disableBehav)
                {
                    //disable behaviours temporarily
                    for (int i = 0; i < behaviourDisable.Length; i++)
                    {
                        behaviourDisable[i].enabled = false;
                    }
                }
                

                postAttackCooldown = postAttackDelay;
                isAttacking = true;

                var boom = Instantiate(boomRang, transform.position, Quaternion.identity);
                boom.GetComponent<ProjBoomrang>().setOwner(this.gameObject);

                audioFunction(true);
            }
        }

        if (!isAttacking && postAttackCooldown > 0)
        {
            postAttackCooldown -= Time.deltaTime;
        }
    }


    //projectile calls this script when entering in contact with owner of this script
    public void backToNormal()
    {
        isAttacking = false;

        if (disableBehav)
        {
            for (int i = 0; i < behaviourDisable.Length; i++)
            {
                behaviourDisable[i].enabled = true;
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
