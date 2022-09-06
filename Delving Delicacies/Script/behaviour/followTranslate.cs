using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTranslate : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float catchupThreshold = 10;
    private GameObject player;
    private Vector3 momentum;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //calculate direction and magnitude of distance between this and player
        momentum =  player.transform.position - transform.position;

        if (Vector2.Distance(transform.position, player.transform.position) > catchupThreshold)
        {
            //zoom to the player (further = faster)
            transform.position += momentum * Time.deltaTime;
        }
        else
        {
            //go at normal pace dictated by variables
            transform.position += momentum.normalized * speed * Time.deltaTime;
        }

        
    }
}
