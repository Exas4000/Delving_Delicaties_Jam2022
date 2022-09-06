using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageUi : MonoBehaviour
{
    //monobehaviour can be improved upon later for
    //multi scene uses

    public GameObject[] UiList;
    
    public List<GameObject[]> ListOfMenu; //list of list for cycling activations

    [SerializeField] bool hasEnteredMenu = false;

    public AudioClip confirm;

    void Start()
    {
        for (int i = 0; i < UiList.Length; i++)
        {
            DisableObject(i);
        }

        if (hasEnteredMenu)
        {
            EnableObject(0);
        }

    }

    

    //code a function to activate/deactivate specific button list
    public void EnableObject(int value)
    {

        UiList[value].SetActive(true);
        
    }

    public void DisableObject(int value)
    {
        UiList[value].SetActive(false);
    }

    
}
