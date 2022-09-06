using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_struct : MonoBehaviour
{
    [SerializeField]public Animator myAnimator;
    [SerializeField] public SpriteRenderer myRender;

    [SerializeField] float walkingThreshold = 1;
    [SerializeField] bool isRevert = false;

    private float scaleX;

    private void Start()
    {
        scaleX = transform.localScale.x;

        if (myAnimator == null)
        {
            myAnimator = GetComponent<Animator>();
        }

        if (myRender == null)
        {
            myRender = GetComponent<SpriteRenderer>();
        }
    }

    public virtual void PassDirectionVector(Vector2 vector2)
    {
        //by default use:
        //"isWalking" for movement
        //"isRevert" for sprite flip
        if (myAnimator != null)
        {
            //is the character walking?
            if (Mathf.Abs(vector2.x) + Mathf.Abs(vector2.y) > walkingThreshold)
            {
                myAnimator.SetBool("isWalking", true);
            }
            else
            {
                myAnimator.SetBool("isWalking", false);
            }

            //is the character looking in the opposite direction?
            if ((vector2.x <= 0 && !isRevert) || (vector2.x >= 0 && isRevert))
            {
                transform.localScale.Set(scaleX, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale.Set(-scaleX, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    public virtual void PassTransform(Transform transform)
    {

    }
}
