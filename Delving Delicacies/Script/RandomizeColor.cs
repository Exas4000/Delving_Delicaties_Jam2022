using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeColor : MonoBehaviour
{
    [SerializeField] Color[] colorList;
    private SpriteRenderer myRender;

    void Start()
    {
        myRender = GetComponent<SpriteRenderer>();

        if (colorList.Length > 0 && myRender != null)
        {
            myRender.color = colorList[Random.Range(0, colorList.Length)];
        }
    }

    
}
