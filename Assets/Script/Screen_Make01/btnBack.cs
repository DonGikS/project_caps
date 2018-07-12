using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnBack : MonoBehaviour {

    public void OnClickButtonBack()
    {
        
        SceneManager.LoadScene("Screen_00");
        
    }
    public void OnClickButtonBack_OnMake()
    {
        SceneManager.LoadScene("Screen_Make01");
    }
}
