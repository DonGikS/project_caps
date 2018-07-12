using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class btnSampleGet : MonoBehaviour
{
    public static string titleName = "";
    public GameObject title;

    public void OnSampleGetClicked()
    {
        // 불러오려는 퍼즐 저장 파일 이름 읽어오기
        titleName = title.GetComponent<Text>().text;

        // 
        Global.loadPuzz = titleName;
        Global.loadPuzz_b = true;

        // 화면 screen02로 전환하면서
        SceneManager.LoadScene("Screen_02");

    }
}
