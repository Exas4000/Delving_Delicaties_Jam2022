using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    //used for continuous damage
    [SerializeField] int damage = 1;
    [SerializeField] bool isFriendlyFire = true;
    [SerializeField] bool hurtEnemy = true;

    

    private void OnTriggerStay2D(Collider2D collision)
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && isFriendlyFire)
        {
            collision.gameObject.GetComponent<PlayerHp>().HurtPlayerHp(damage);
        }

        if (collision.collider.tag == "Enemy" && hurtEnemy)
        {
            //change this for hp script on the enemy
            collision.gameObject.GetComponent<MonHP>().HurtMonsterHp(damage);
        }
    }
}
