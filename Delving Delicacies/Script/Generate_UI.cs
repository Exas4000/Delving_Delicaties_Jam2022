using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generate_UI : MonoBehaviour
{

    [SerializeField] int startingHp = 3;
    [SerializeField] GameObject[] kobolds;

    [SerializeField] GameObject lifeIcon; //object to be modified depending on hp lost
    [SerializeField] Sprite healthy; //sprite for hp
    [SerializeField] Transform drawPosition;//spot to start drawing the life icons
    [SerializeField] float spacing = 0.2f; //spacing 
    private List<GameObject> lifeIndicator = new List<GameObject>();

    void Start()
    {
        DrawKobold();
        CreateHeart();
        DrawHeart(startingHp);
    }


    public void DrawKobold()
    {
        //decide how many kobolds live indicator to be disabled
        for (int i = 0; i < PlayerPrefs.GetInt("Death") && i < kobolds.Length; i++)
        {
            kobolds[i].SetActive(false);
        }
    }

    private void CreateHeart()
    {
        //produce heart object and add them to the list
        for (int i = 0; i < startingHp;i++)
        { 


            var icon = Instantiate(lifeIcon, drawPosition.position + new Vector3(spacing * i, 0, 0), drawPosition.rotation );
            icon.transform.parent = drawPosition.transform;
            lifeIndicator.Add(icon);

            
        }

    }

    public void DrawHeart(int value)
    {
        //adjust the hp indicator to match the current hp of the player
        for (int i = 0; i < startingHp; i++)
        {
            if (i < value)
            {
                lifeIndicator[i].GetComponent<Image>().color = Color.blue;
            }
            else
            {
                lifeIndicator[i].GetComponent<Image>().color = Color.red;
            }
        }

    }
}
