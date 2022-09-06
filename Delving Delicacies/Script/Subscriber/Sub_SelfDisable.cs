using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_SelfDisable : Subscriber
{
    public override void OnPlayerDeath()
    {
        base.OnPlayerDeath();
        this.gameObject.SetActive(false);
    }

    public override void OnPlayerWin()
    {
        base.OnPlayerWin();
        this.gameObject.SetActive(false);
    }
}
