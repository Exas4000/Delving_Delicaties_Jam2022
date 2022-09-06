using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonHpDisabler : MonoBehaviour
{
    [SerializeField] int MaxMonHp = 3;
    private int monHp;

    [SerializeField] float invincibilityTime = 0;
    private float invinTimer = 0;

    [SerializeField] float stunTimeDelay = 0;
    private float stunTimer = 0;
    private bool isStunned = false;

    [SerializeField] bool dropLoot = false;
    [SerializeField] GameObject[] loot;
    [SerializeField] public Observer myObserver; //if we wanna  

    [SerializeField] MonoBehaviour[] toDisable;

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

        if (stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
        }
        else if (isStunned)
        {
            StunMonster(false);
            monHp = MaxMonHp;
        }

        if (monHp > MaxMonHp)
        {
            monHp = MaxMonHp;
        }

        if (monHp <= 0)
        {
            monHp = 0;

            StunMonster(false);
            //call observer for monster death if necessary

        }

    }

    public void StunMonster(bool isNotStun)
    {
        for (int i = 0; i < toDisable.Length; i++)
        {
            toDisable[i].enabled = isNotStun;
        }

        isStunned = isNotStun;
    }
}
