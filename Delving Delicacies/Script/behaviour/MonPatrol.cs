using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonPatrol : MonoBehaviour
{
    [SerializeField] float speed = 10;
    [SerializeField] float proximityThreshold = 1; //distance needed before seeking next node.

    [SerializeField] Vector2[] nodes;
    private int currentNode = 0;
    private bool isGoingBack = false;

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
        //if close enough from the node, change node to reach
        if (Vector2.Distance(transform.position, nodes[currentNode]) <= proximityThreshold)
        {
            NextNode();
        }

        //move toward current node!
        direction = nodes[currentNode] - new Vector2 (transform.position.x,transform.position.y);
        myRB.AddForce(new Vector2(direction.x, direction.y).normalized * speed * Time.deltaTime);

        if (myAnim != null)
        {
            myAnim.PassDirectionVector(direction);
        }

        if (soundCooldown <= 0)
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

    public void NextNode()
    {
        
        if (!isGoingBack)
        {
            if (currentNode == (nodes.Length) - 1)
            {
                isGoingBack = true;
                currentNode -= 1;
                return;
            }

            currentNode += 1;
        }
        else
        {
            if (currentNode == 0)
            {
                isGoingBack = false;
                currentNode += 1;
                return;
            }

            currentNode -= 1;
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
