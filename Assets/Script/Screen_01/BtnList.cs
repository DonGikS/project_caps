using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BinaryFormatter를 사용하기 위해서
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnList : MonoBehaviour {
    public static string titleName ="";
    public GameObject title;
    public List<GameObject> clicked= new List<GameObject>();

    void Start()
    {
    }

    public void OnClickBtnGet() // 퍼즐 불러오기 버튼
    {
        // 다른것들은 비활성화하고
        GameObject[] go = GameObject.FindGameObjectsWithTag("SampleClicked");
        for (int i = 0; i < go.Length; i++)
        {
            go[i].SetActive(false);
        }
        //내가 클릭한 것만 활성화
        clicked[0].SetActive(true);
        clicked[1].SetActive(true);
    }
    
    public void setText(String _str)
    {
        title.GetComponent<Text>().text = _str;
    }
}
