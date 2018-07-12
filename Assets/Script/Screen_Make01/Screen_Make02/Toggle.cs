using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle : MonoBehaviour {

    private string Theme;
    public Toggle toggle;

    void Start()
    {
        Theme = this.gameObject.AddComponent<AudioSource>().name;
    }

    public void ToggleValueChanged(Toggle _toggle)
    {
        GameObject.Find("SettingData").GetComponent<SettingData>().setTheme(_toggle.GetComponent<AudioSource>().name);
    }
}
