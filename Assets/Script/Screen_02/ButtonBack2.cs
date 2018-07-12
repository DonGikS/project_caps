using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBack2 : MonoBehaviour
{
    public void OnClickButtonBack2()
    {
        // if 현재 스크린 Screen_02
        SceneManager.LoadScene("Screen_01");
        //Debug.Log("저장된거 확인용");
        //GameObject.Find("PuzzleData").GetComponent<PuzzleData>().GetPuzz();
    }
}

