using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checktoggle : MonoBehaviour {
    public int chkToggle;
    public int toggleBox;
    public GameObject Me;
	// Use this for initialization
	void Start () {
        

        
        
    }
	
	// Update is called once per frame
	void Update () {
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        Color color = spr.color;
        toggleBox = GameObject.Find("SettingData").GetComponent<SettingData>().theme_idx;
        if (chkToggle == toggleBox)
        {
            color.a = 1f;
            spr.color = color;
            
        }
        else
        {
            color.a = 0f;
            spr.color = color;
        }

    }
}
