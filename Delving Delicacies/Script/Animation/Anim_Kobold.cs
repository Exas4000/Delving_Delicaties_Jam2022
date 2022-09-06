using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Kobold : Anim_struct
{
    public override void PassDirectionVector(Vector2 vector2)
    {
        base.PassDirectionVector(vector2);

        if (vector2.x > 0)
        {
            myRender.flipX = false;
        }

        if (vector2.x < 0)
        {
            myRender.flipX = true;
        }
    }
}
