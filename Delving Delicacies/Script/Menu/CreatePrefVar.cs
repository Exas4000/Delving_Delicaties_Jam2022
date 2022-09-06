using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefVar : MonoBehaviour
{
    //initialise and create variable that stick between sessions
    void Start()
    {
        if (!PlayerPrefs.HasKey("DroppedLoot"))
        {
            PlayerPrefs.SetInt("DroppedLoot", 0);
        }

        if (!PlayerPrefs.HasKey("Death"))
        {
            PlayerPrefs.SetInt("Death", 0);
        }

        if (!PlayerPrefs.HasKey("DeathX"))
        {
            PlayerPrefs.SetFloat("DeathX", 0);
        }

        if (!PlayerPrefs.HasKey("DeathY"))
        {
            PlayerPrefs.SetFloat("DeathY", 0);
        }
    }

    
    public void ProgressionReset()
    {
        PlayerPrefs.SetInt("DroppedLoot", 0);
        PlayerPrefs.SetInt("Death", 0);
        PlayerPrefs.SetFloat("DeathX", 0);
        PlayerPrefs.SetFloat("DeathY", 0);
    }
}
