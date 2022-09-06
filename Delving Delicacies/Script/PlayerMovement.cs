using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] float speed = 10;
    private Rigidbody2D myRigidBody;

    private Vector2 momentum = new Vector2(0, 0);
    private Vector3 scale;
    [SerializeField] Anim_struct myAnim;

    [SerializeField] AudioSource mySound;
    [SerializeField] float soundDelay = 0.2f;
    private float soundCooldown = 0;
    private bool pitch = true;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        scale = transform.localScale;

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
        //handle momentum addition
        momentum = new Vector2(0, 0);

        CalculateMomentum(0, -1);

        
        myRigidBody.AddForce(momentum,ForceMode2D.Impulse);


        if (Mathf.Abs(myRigidBody.velocity.x + myRigidBody.velocity.y) >= 1 && momentum != new Vector2(0, 0))
        {
            if (soundCooldown <= 0)
            {
                audioFunction(true);
                pitch = !pitch;
                soundCooldown = soundDelay;
            }
            else
            {
                soundCooldown -= Time.deltaTime;
            }            
        }
    }

    public void CalculateMomentum(float force, int direction)
    {
        if (InputManager.pressDown)
        {
            momentum += new Vector2(0, -speed * Time.deltaTime);

            if (direction == 0)
            {
                momentum += new Vector2(0, -force * Time.deltaTime);
            }
        }

        if (InputManager.pressLeft)
        {
            momentum += new Vector2(-speed * Time.deltaTime, 0);

            if (direction == 1)
            {
                momentum += new Vector2(-force * Time.deltaTime, 0);
            }
        }

        if (InputManager.pressUp)
        {
            momentum += new Vector2(0, speed * Time.deltaTime);

            if (direction == 2)
            {
                momentum += new Vector2(0, speed * Time.deltaTime);
            }
        }

        if (InputManager.pressRight)
        {
            momentum += new Vector2(speed * Time.deltaTime, 0);

            if (direction == 3)
            {
                momentum += new Vector2(speed * Time.deltaTime, 0);
            }
        }

        if (myAnim != null)
        {
            myAnim.PassDirectionVector(momentum/Time.deltaTime);
           
        }
    }

    private void audioFunction(bool pitch)
    {
        if (pitch)
        {
            mySound.pitch = Random.Range(0.5f,1);
        }
        else
        {
            mySound.pitch = 1f;
        }

        mySound.Play();
    }

    private void adjustVolume()
    {
        mySound.volume = PlayerPrefs.GetFloat("Volume_Sound");
    }
}
