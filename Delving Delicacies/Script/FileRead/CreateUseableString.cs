using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI; //remove later once testing works


public class CreateUseableString : MonoBehaviour
{
    /*
    *This Script is made to convert text Files into Public Arrays
    *that can be used to display Text.
    *
    *Also prepare the narrator itself for uses between scenes
    */

    public static string[] textbox_death; //Array containing the initial text for the intro
    public static string[] textbox_hurt;
    public static string[] textbox_loot_normal;
    public static string[] textbox_milestone;

    string myFilePath, fileName;


    

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject); //should prevent self destruction between scenes.

        /*
        fileName = "Scene_1.txt"; //set the name of the file to be converted to the array
        myFilePath = Application.streamingAssetsPath + "/" + fileName; //produce the filepath
        Scene_1 = File.ReadAllLines(myFilePath); //convert .txt to string array

        fileName = "Scene_2.txt"; //set the name of the file to be converted to the array
        myFilePath = Application.streamingAssetsPath + "/" + fileName; //produce the filepath
        Scene_2 = File.ReadAllLines(myFilePath); //convert .txt to string array

        fileName = "Scene_fin.txt"; //set the name of the file to be converted to the array
        myFilePath = Application.streamingAssetsPath + "/" + fileName; //produce the filepath
        Scene_end = File.ReadAllLines(myFilePath); //convert .txt to string array
        */

        textbox_death = CompileString("textbox_death.txt");
        textbox_hurt = CompileString("textbox_hurt.txt");
        textbox_loot_normal = CompileString("textbox_loot_normal.txt");
        textbox_milestone = CompileString("textbox_milestone.txt");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    ///produce a function that repeat the start function, but for different .txt and array
    private string[] CompileString(string file)
    {
        string[] variable;

        fileName = file; //set the name of the file to be converted to the array
        myFilePath = Application.streamingAssetsPath + "/" + fileName; //produce the filepath
        variable = File.ReadAllLines(myFilePath); //convert .txt to string array

        return variable;
    }
}
