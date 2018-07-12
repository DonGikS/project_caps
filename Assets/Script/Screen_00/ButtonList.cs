using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonList : MonoBehaviour {

    public void OnListClick()
    {
        SceneManager.LoadScene("Screen_01");
    }
}
