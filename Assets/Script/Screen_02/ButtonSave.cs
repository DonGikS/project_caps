using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSave : MonoBehaviour {

    public GameObject PopupPanel;

    public void OnClickBtnSave()
    {
        if (PopupPanel.activeSelf == false)
        {
            PopupPanel.SetActive(true);
        }
        else
        {
            PopupPanel.SetActive(false);
        }

    }
}
