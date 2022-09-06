using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cutscene_manager : MonoBehaviour
{
    [System.Serializable]
    public struct Slide
    {

        public int milestoneRequirement;
        public string stringText;
        public Sprite cutsceneImage;

        public Slide(int milestone, string sentence, Sprite image)
        {
            this.milestoneRequirement = milestone;
            this.stringText = sentence;
            cutsceneImage = image;
        }

        
    }

    [SerializeField] int nextSceneID = 0;
    [SerializeField] Slide[] completeCutscene;
    private int currentSlide = 0;

    //user interface elements
    [SerializeField] Image image;
    [SerializeField] Text textbox;

    void Start()
    {
        if (completeCutscene.Length <= 0)
        {
            SceneManager.LoadScene(nextSceneID);
        }
        else
        {
            SetSlide(0);
        }

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.anyKeyDown)
        {
            NextSlide();
        }
    }

    public void SetSlide(int SlideID)
    {
        if (SlideID < completeCutscene.Length)
        {
            image.sprite = completeCutscene[SlideID].cutsceneImage;
            textbox.text = completeCutscene[SlideID].stringText;

            currentSlide = SlideID;
        }
    }

    public void NextSlide()
    {
        currentSlide += 1;

        if (currentSlide < completeCutscene.Length)
        {
            if (PlayerPrefs.GetInt("rank") >= completeCutscene[currentSlide].milestoneRequirement)
            {
                image.sprite = completeCutscene[currentSlide].cutsceneImage;
                textbox.text = completeCutscene[currentSlide].stringText;
            }
            else
            {
                SceneManager.LoadScene(nextSceneID);
            }
            
        }
        else
        {
            SceneManager.LoadScene(nextSceneID);
        }

    }

    
}
