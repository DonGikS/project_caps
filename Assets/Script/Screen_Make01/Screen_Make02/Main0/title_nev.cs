using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title_nev : MonoBehaviour {

    //private Transform title_text;
    bool isHide = true;

	// Use this for initialization
	void Start () {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color col = sr.color;
        col.a = 0;
        sr.color = col;
    }
	
	// Update is called once per frame
	void Update () {
        PlayFadeIn();
	}

    void PlayFadeIn()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        //sr.color = new Color(1, 1, 1, alphaLevel);

        if (isHide)
        {
            Color col = sr.color;
            col.a = col.a - Time.deltaTime;

            if (col.a < 0)
            {
                col.a = 0.0f;
                isHide = false;
            }

            sr.color = col;
        }
        else
        {
            Color col = sr.color;
            col.a = col.a + Time.deltaTime;

            if (col.a > 1)
            {
                col.a = 1.0f;
                isHide = true;
            }

            sr.color = col;
        }
    }
}
