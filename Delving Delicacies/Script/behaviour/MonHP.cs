using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonHP : MonoBehaviour
{
    [SerializeField] int MaxMonHp = 3;
    private int monHp;

    [SerializeField] float invincibilityTime = 0;
    private float invinTimer = 0;

    [SerializeField] bool dropLoot = false;
    [SerializeField] GameObject[] loot;
    [SerializeField] public Observer myObserver; //if we wanna  

    // Start is called before the first frame update
    void Start()
    {
        monHp = MaxMonHp;

        if (myObserver == null)
        {
            GameObject tempObs = GameObject.FindGameObjectsWithTag("Observer")[0];

            if (tempObs != null)
            {
                myObserver = tempObs.GetComponent<Observer>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (invinTimer > 0)
        {
            invinTimer -= Time.deltaTime;
        }
    }

    public void HurtMonsterHp(int value)
    {


        if (invinTimer <= 0)
        {
            //if not during invincibility frames, hurt and set invulnerability
            monHp -= value;
            invinTimer = invincibilityTime;
            //call observer for monster hurt if necessary
            
        }


        if (monHp > MaxMonHp)
        {
            monHp = MaxMonHp;
        }

        if (monHp <= 0)
        {
            monHp = 0;

            killMonster();
            //call observer for monster death if necessary
           
        }

    }

    public void killMonster()
    {
        if (dropLoot && loot != null)
        {
            int lootID = Random.Range(0, loot.Length);
            Instantiate(loot[lootID], transform.position,transform.rotation);
        }

        //can add delay stuff animation and such
        Destroy(this.gameObject);
    }
}
