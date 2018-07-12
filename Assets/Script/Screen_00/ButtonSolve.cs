using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSolve : MonoBehaviour
{ 
    public void OnClickSolve()
    {
        SceneManager.LoadScene("Screen_Make01");
    }

}
