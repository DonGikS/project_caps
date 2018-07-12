using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBack : MonoBehaviour
{
    public void OnClickBack()
    {
        // if 현재 스크린 Screen_01
        SceneManager.LoadScene("Screen_00");
    }
    
}
