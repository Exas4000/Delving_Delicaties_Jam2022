using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_hpBar : Subscriber
{
    [SerializeField] Generate_UI myScript;

    // Update is called once per frame
    public override void OnHealthChangeEvent(int playerHp)
    {
        base.OnHealthChangeEvent(playerHp);
        //call draw event for the ui
        myScript.DrawHeart(playerHp);
    }

    public override void OnPlayerDeath()
    {
        base.OnPlayerDeath();
        myScript.DrawKobold();
    }
}
