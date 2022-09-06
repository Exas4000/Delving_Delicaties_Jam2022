using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjBoomrang : MonoBehaviour
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

    [SerializeField] SpriteRenderer myRender;
    [SerializeField] Sprite[] mySprites;

    //private Camera mainCam;
    //private Vector3 mousePos;

    private GameObject player;
    private GameObject Owner;

    void Start()
    {
        //mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");

        myRB = GetComponent<Rigidbody2D>();

        direction = player.transform.position - transform.position;
        Vector3 rotation = transform.position - player.transform.position;

        myRB.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        reverse = lifeTime;
    }

    
    void Update()
    {
        if (myRender != null && mySprites.Length > 1)
        {
            if ((direction.y >= 0 && lifeTime > 0) || (direction.y < 0 && lifeTime <= 0))
            {
                myRender.sprite = mySprites[0];
            }
            else
            {
                myRender.sprite = mySprites[1];
            }
        }

        
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
            myRB.velocity = new Vector2(-direction.x, -direction.y).normalized * speed;

            if (reverse <= 0)
            {
                if (Owner != null)
                {
                    Owner.GetComponent<BoomerangSpawner>().backToNormal();
                }               
                Destroy(this.gameObject);
            }
            else
            {
                reverse -= Time.deltaTime;
            }
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
        }

        if (collision.tag == "Enemy" && hurtEnemy)
        {
            //change this for hp script on the enemy
            collision.gameObject.GetComponent<MonHP>().HurtMonsterHp(damage);
        }

        if (collision.gameObject == Owner && lifeTime <= 0)
        {
            collision.gameObject.GetComponent<BoomerangSpawner>().backToNormal();
            Destroy(this.gameObject);
        }
    }

    public void setOwner(GameObject gameowner)
    {
        Owner = gameowner;
    }
}
