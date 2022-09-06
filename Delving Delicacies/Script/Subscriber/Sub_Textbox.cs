using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sub_Textbox : Subscriber
{

    [SerializeField] GameObject textBox;
    [SerializeField] GameObject image;

    [SerializeField] Sprite[] Expressions;

    [SerializeField] float timeStayUp = 10;
    private float timer = 0;
    private bool isActive = false;
    private bool imageActive = false;

    void Update()
    {
        //handling the time a textbox stays visible/active.


        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            isActive = false;
            imageActive = false;
            image.GetComponent<Image>().sprite = Expressions[0];
        }

        textBox.SetActive(isActive);
        //image.SetActive(imageActive);
        
    }

    public override void OnPlayerDeath()
    {
        base.OnPlayerDeath();

        int deathQuote = Random.Range(0, CreateMessages.mes_death.Count);

        isActive = true;
        textBox.SetActive(true);
        textBox.GetComponent<Text>().text = CreateUseableString.textbox_death[CreateMessages.mes_death[deathQuote].stringID];

        if (CreateMessages.mes_death[deathQuote].expressionID >= 0)
        {
            imageActive = true;
            image.SetActive(true);

            image.GetComponent<Image>().sprite = Expressions[CreateMessages.mes_death[deathQuote].expressionID];
        }

        timer = timeStayUp;
    }

    public override void OnScoreEvent(float score)
    {
        base.OnScoreEvent(score);

        if (Random.Range(0,7) == 0)
        {
            int Quote = Random.Range(0, CreateMessages.mes_lootCollect.Count);

            isActive = true;
            textBox.SetActive(true);
            textBox.GetComponent<Text>().text = CreateUseableString.textbox_loot_normal[CreateMessages.mes_lootCollect[Quote].stringID];

            if (CreateMessages.mes_lootCollect[Quote].expressionID >= 0)
            {
                imageActive = true;
                image.SetActive(true);

                image.GetComponent<Image>().sprite = Expressions[CreateMessages.mes_lootCollect[Quote].expressionID];
            }

            timer = timeStayUp;
        }
    }

    public override void OnHealthChangeEvent(int playerHp)
    {
        base.OnHealthChangeEvent(playerHp);

        if (Random.Range(0, 2) == 0)
        {
            int Quote = Random.Range(0, CreateMessages.mes_playerHurt.Count);

            isActive = true;
            textBox.SetActive(true);
            textBox.GetComponent<Text>().text = CreateUseableString.textbox_hurt[CreateMessages.mes_playerHurt[Quote].stringID];

            if (CreateMessages.mes_playerHurt[Quote].expressionID >= 0)
            {
                imageActive = true;
                image.SetActive(true);

                image.GetComponent<Image>().sprite = Expressions[CreateMessages.mes_playerHurt[Quote].expressionID];
            }

            timer = timeStayUp;
        }
    }

    public override void OnMilestoneChange()
    {
        base.OnMilestoneChange();

        isActive = true;
        textBox.SetActive(true);
        //rank 1 should play the line "0" of the list of string, as such we use (rank-1)
        textBox.GetComponent<Text>().text = CreateUseableString.textbox_milestone[CreateMessages.mes_milestone[PlayerPrefs.GetInt("rank")-1].stringID];

        if (CreateMessages.mes_milestone[PlayerPrefs.GetInt("rank") - 1].expressionID >= 0)
        {
            imageActive = true;
            image.SetActive(true);

            image.GetComponent<Image>().sprite = Expressions[CreateMessages.mes_milestone[PlayerPrefs.GetInt("rank") - 1].expressionID];
        }

        timer = timeStayUp;
    }
}
