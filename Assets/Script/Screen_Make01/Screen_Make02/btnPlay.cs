using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btnPlay : MonoBehaviour {

    AudioSource aud;
    public AudioClip[] ac;
    int theme_idx;

    AudioSource playMusic;
    
    void Start()
    {
    }

    public void OnBtnPlayClicked()
    {
        theme_idx = GameObject.Find("SettingData").GetComponent<SettingData>().theme_idx;
        aud = GetComponent<AudioSource>();
        aud.clip = ac[theme_idx];
        aud.Play();
        
    }

   
}
