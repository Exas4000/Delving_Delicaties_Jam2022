using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreateMessages : MonoBehaviour
{

    //this whole script is made to be used by non-programmer to be able to have specific expressions along with specific lines of dialogue.

    [System.Serializable]
    public  struct messages
    {
        
        public int expressionID;
        public int stringID;

        public messages(int expression, int stringNum)
        {
            this.expressionID = expression;
            this.stringID = stringNum;
        }

        public int ReturnExpressionID()
        {
            return expressionID;
        }

        public int ReturnStringID()
        {
            return stringID;
        }
    }

    [SerializeField] messages[] deathMessage;
    [SerializeField] messages[] milestoneMessage;
    [SerializeField] messages[] lootCollect;
    [SerializeField] messages[] playerHurt;

    public static List<messages> mes_death = new List<messages>();
    public static List<messages> mes_milestone = new List<messages>();
    public static List<messages> mes_lootCollect = new List<messages>();
    public static List<messages> mes_playerHurt = new List<messages>();


    void Start()
    {
        //compile arrays into list
        compileMessages(deathMessage, mes_death);
        compileMessages(milestoneMessage, mes_milestone);
        compileMessages(lootCollect, mes_lootCollect);
        compileMessages(playerHurt, mes_playerHurt);

    }


    private void compileMessages(messages[] toCompile, List<messages> compileTarget)
    {
        for (int i = 0; i < toCompile.Length; i++)
        {
            compileTarget.Add(toCompile[i]);
        }
    }

}
