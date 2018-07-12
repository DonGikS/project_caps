using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAdd : MonoBehaviour {

    public void OnClickAdd()
    {
        SceneManager.LoadScene("Screen_02");
    }

    /*
    private GameObject popupView;

    private void OnMouseDown()
    {
        popupView = GameObject.FindGameObjectWithTag("PopupView");
        popupView.SetActive(true);
    }
    */

}
