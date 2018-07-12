using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonRepeat : MonoBehaviour {

    private bool isRepeat;

    public void OnClickRepeat()
    {
        if(isRepeat)
        {
            this.gameObject.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
            isRepeat = false;
        }
        else
        {
            this.gameObject.GetComponent<Image>().color = new Color(150.0f / 255.0f, 150.0f / 255.0f, 150.0f / 255.0f);
            isRepeat = true;
        }
    }

    public bool GetIsRepeat()
    {
        return isRepeat;
    }

    private void Start()
    {
        isRepeat = false;
    }

}
