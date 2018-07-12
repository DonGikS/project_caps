using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMake : MonoBehaviour {

    public void OnClickMake()
    {
        SceneManager.LoadScene("Screen_02");
    }
}
