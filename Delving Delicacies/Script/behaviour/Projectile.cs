using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //used for continuous damage
    [SerializeField] int damage = 1;
    [SerializeField] bool isFriendlyFire = true;
    [SerializeField] bool hurtEnemy = true;
    [SerializeField] float speed = 10;
    [SerializeField] float lifeTime = 3;

    [SerializeField] Vector2 manualDirection = new Vector2(0, 0);
    private bool isManual = false;
    private Rigidbody2D myRB;

    private Camera mainCam;
    private Vector3 mousePos;

    [SerializeField] public Observer myObserver;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        if (manualDirection != new Vector2(0,0))
        {
            isManual = true;
        }
        myRB = GetComponent<Rigidbody2D>(); 
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        myRB.velocity = new Vector2(direction.x, direction.y).normalized * speed;

        //finding the observer
        if (myObserver == null)
        {
            GameObject tempObs = GameObject.FindGameObjectsWithTag("Observer")[0];

            if (tempObs != null)
            {
                myObserver = tempObs.GetComponent<Observer>();
            }
        }
    }

    void Update()
    {
        
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
            myObserver.BulletEvent();
            Destroy(this.gameObject);
        }

        if (collision.tag == "Enemy" && hurtEnemy)
        {
            //change this for hp script on the enemy
            collision.gameObject.GetComponent<MonHP>().HurtMonsterHp(damage);
            myObserver.BulletEvent();
            Destroy(this.gameObject);
        }
    }

    public void makeManual(Vector2 direction)
    {
        manualDirection = direction;
        isManual = true;
    }

    
}
