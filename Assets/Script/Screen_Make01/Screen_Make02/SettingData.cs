using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingData : MonoBehaviour {
    
    public int theme_idx;

    void Start()
    {
        // 처음에 theme 아무 설정안해주면 '개구쟁이'로 기본 설정
        theme_idx = 0;
    }

    public void setTheme(string _name)
    {
        //playMusic = _go.GetComponent<AudioSource>();
        if (_name.Equals("toggle0")){
            theme_idx = 0;
        }else if (_name.Equals("toggle1")){
            theme_idx = 1;
        }else if (_name.Equals("toggle2")){
            theme_idx = 2;
        }else if (_name.Equals("toggle3")){
            theme_idx = 3;
        } else if (_name.Equals("toggle4")){
            theme_idx = 4;
        }
    }
 }
