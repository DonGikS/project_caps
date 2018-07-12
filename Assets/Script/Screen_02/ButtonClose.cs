using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClose : MonoBehaviour {

    public GameObject PopupPanel;

    public void OnClickBtnClose()
    {
        // input filed 비우고
        // PopupPanel 보이지 않게하기
        PopupPanel.SetActive(false);


    }
}
