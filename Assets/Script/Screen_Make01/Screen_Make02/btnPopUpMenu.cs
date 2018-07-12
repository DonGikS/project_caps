using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnPopUpMenu : MonoBehaviour {
    public GameObject PopUpMenu;

    public void OnClickPopUpMenu()
    {
        if (PopUpMenu.activeSelf == false)
        {
            PopUpMenu.SetActive(true);
        }
        else
        {
            PopUpMenu.SetActive(false);
        }
    }
    public void OnClickPopUpMenuClose()
    {
        PopUpMenu.SetActive(false);
    }
}
