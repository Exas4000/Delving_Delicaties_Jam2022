using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonProjectile : MonoBehaviour
{
    //used for continuous damage
    [SerializeField] int damage = 1;
    [SerializeField] bool isFriendlyFire = true;
    [SerializeField] bool hurtEnemy = true;
    [SerializeField] float speed = 10;
    [SerializeField] float lifeTime = 3;
    private float reverse = 0;
    private Vector3 direction;

    [SerializeField] Vector2 manualDirection = new Vector2(0, 0);
    private bool isManual = false;
    private Rigidbody2D myRB;


    //private Camera mainCam;
    //private Vector3 mousePos;

    private GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        myRB = GetComponent<Rigidbody2D>();

        direction = player.transform.position - transform.position;
        Vector3 rotation = transform.position - player.transform.position;

        myRB.velocity = new Vector2(direction.x, direction.y).normalized * speed;
    }



    private void FixedUpdate()
    {

        Vector2 momentum;

        if (isManual)
        {
            momentum = manualDirection;
            myRB.velocity = momentum;
        }


        if (lifeTime <= 0)
        {                          
            Destroy(this.gameObject);  
        }
        else
        {
            lifeTime -= Time.deltaTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isFriendlyFire)
        {
            collision.gameObject.GetComponent<PlayerHp>().HurtPlayerHp(damage);
            Destroy(this.gameObject);
        }

        if (collision.tag == "Enemy" && hurtEnemy)
        {
            //change this for hp script on the enemy
            collision.gameObject.GetComponent<MonHP>().HurtMonsterHp(damage);
            Destroy(this.gameObject);
        }

    }
}
