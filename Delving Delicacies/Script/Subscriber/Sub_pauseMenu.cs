using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_pauseMenu : Subscriber
{
    private bool canPause = true;
    private bool isPaused = false;
    [SerializeField] ManageUi menu;

    // Update is called once per frame
    void Update()
    {
        if (InputManager.pressEsq && canPause)
        {
            Debug.Log("calling switch");

            switch (isPaused)
            {
                case true:
                    {
                        myObserver.CallPause(false);
                        isPaused = false;
                        return;
                    }
                case false:
                    {
                        myObserver.CallPause(true);
                        isPaused = true;
                        return;
                    }
                
            }
                
     
        }
    }

    public override void OnPause()
    {
        menu.EnableObject(0);
    }

    public override void OnResumeFromPause()
    {
        menu.DisableObject(0);
    }

}
