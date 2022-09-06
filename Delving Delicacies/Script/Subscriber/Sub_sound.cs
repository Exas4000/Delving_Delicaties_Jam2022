using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_sound : Subscriber
{
    [SerializeField] SoundFunctions mySound;
    [SerializeField] AudioClip lootSound;
    [SerializeField] AudioClip bulletHitSound;
    [SerializeField] AudioClip hurtSound;


    public override void OnScoreEvent(float score)
    {
        base.OnScoreEvent(score);

        mySound.playSound(lootSound);
    }

    public override void OnBulletCollide()
    {
        base.OnBulletCollide();
        mySound.playSound(bulletHitSound);

    }

    public override void OnHealthChangeEvent(int playerHp)
    {
        base.OnHealthChangeEvent(playerHp);
        mySound.playSound(hurtSound);
    }

}
