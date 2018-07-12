using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlay : MonoBehaviour
{
    public GameObject playView;

    public void OnClickPlay()
    {
        if (playView.activeSelf == false)
        {
            playView.SetActive(true);
            playView.SendMessage("PlayOn");
        }
        else
        {
            playView.SendMessage("PlayOff");
            playView.SetActive(false);
        }
    }
}
