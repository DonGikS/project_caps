using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen02Tutorial : MonoBehaviour {

    public GameObject screenController;
    public GameObject puzzleView;

    public GameObject tutorialImg_00;
    public GameObject tutorialImg_01;
    public GameObject tutorialImg_02;
    public GameObject tutorialImg_03;

    private bool isDone = false;
    private int step = 0;

    private List<GameObject> tutorialImgs = new List<GameObject>();

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        //AddToTutorialList();
    }

    private void AddToTutorialList()
    {
        tutorialImgs.Add(tutorialImg_00);
        tutorialImgs.Add(tutorialImg_01);
        tutorialImgs.Add(tutorialImg_02);
        tutorialImgs.Add(tutorialImg_03);
    }

    private void StartTutorial()
    {
        if (isDone)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            AddToTutorialList();
            step = 0;
            //Debug.Log(tutorialImgs[step].name);
            tutorialImgs[step].SetActive(true);
        }
    }

    private void FadeInOut()
    {
        tutorialImgs[step - 1].SetActive(false);
        tutorialImgs[step].SetActive(true);
        if(step == 1)
        {
            puzzleView.SetActive(true);
        }
        else if(step == 2)
        {
            puzzleView.SetActive(false);
        }
    }

    private void Update()
    {
        //Debug.Log(tutorialImgs[step].name);
        if (Input.GetMouseButtonUp(0))
        {
            if(step > 2)
            {
                screenController.SetActive(true);
                isDone = true;
                this.gameObject.SetActive(false);
            }
            else
            {
                step++;
                FadeInOut();
            }
        }
    }
}
