using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonMenu : MonoBehaviour {

    //public GameObject MenuPanel;
    public GameObject btnBack;
    public GameObject btnSave;
    public GameObject puzzleView;

    public void OnClickPuzzleMenu()
    {
        if (btnBack.activeSelf == false)
        {
            btnBack.SetActive(true);
            btnSave.SetActive(true);
            puzzleView.SetActive(false);
        }
        else
        {
            btnBack.SetActive(false);
            btnSave.SetActive(false);
            //puzzleView.SetActive(false);
        }
        /*
        if (MenuPanel.activeSelf == false)
        {
            MenuPanel.SetActive(true);
        }
        else
        {
            MenuPanel.SetActive(false);
        }
        */
    }
}
