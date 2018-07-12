using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayController : MonoBehaviour {

    public float delayTime;
    public float movingTimeSec;
    public GameObject PlayBar;
    public GameObject btnPlay;
    public GameObject btnRepeat;

    private bool isPlay;
    private float deltaTimeSpeed;
    private float deltaFrameSpeed;
    private Vector2 PlayBarPos;

    private void PlayOn()
    {
        isPlay = true;
        btnPlay.GetComponent<Image>().color = new Color(150.0f / 255.0f, 150.0f / 255.0f, 150.0f / 255.0f);
    }

    private void PlayOff()
    {
        isPlay = false;
        btnPlay.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
        Init();
    }

    private void Playing()
    {
        // x:50 ~ x:320 pivot - left anchor
        // = 250
        PlayBarPos = PlayBar.transform.position;
        //Debug.Log(PlayBarPos);
        if(PlayBarPos.x >= 5.4)
        {
            if(btnRepeat.GetComponent<ButtonRepeat>().GetIsRepeat())
            {
                Init();
            }
            else
            {
                PlayOff();
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            PlayBarPos.x = PlayBarPos.x + deltaFrameSpeed;
            PlayBar.transform.position = PlayBarPos;
        }
        return;
    }

    private void Init()
    {
        deltaTimeSpeed = 250 / movingTimeSec;
        deltaFrameSpeed = deltaTimeSpeed * Time.deltaTime;
        PlayBarPos = PlayBar.transform.position;
        PlayBarPos.x = -3.9f;
        PlayBar.transform.position = PlayBarPos;
    }

    private void Start()
    {
        Debug.Log(PlayBar.transform.position);
        isPlay = false;
        Init();
    }

    // Update is called once per frame
    void Update () {
		if(isPlay)
        {
            Playing();
        }
	}
}
