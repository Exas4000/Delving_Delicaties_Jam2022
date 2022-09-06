using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{

    [SerializeField] Vector3 teleportPosition = new Vector3(0,0,0);
    private GameObject player;

    [SerializeField] GameObject targetLevel;
    [SerializeField] GameObject levelToDisable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //register player
            player = collision.gameObject;

            //set target level active
            targetLevel.SetActive(true);

            //move player
            Rigidbody2D targetRB = player.GetComponent<Rigidbody2D>();

            targetRB.bodyType = RigidbodyType2D.Kinematic;

            targetRB.MovePosition(new Vector2 (teleportPosition.x,teleportPosition.y));
            player.transform.position = teleportPosition;

            targetRB.bodyType = RigidbodyType2D.Dynamic;


            //disable the level the player left
            levelToDisable.SetActive(false);
        }
    }

    
}
