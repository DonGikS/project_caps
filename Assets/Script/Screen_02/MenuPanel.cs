using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public GameObject btnMenu;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(
            btnMenu.transform.position.x - 4,
            btnMenu.transform.position.y,
            0);
    }

    /*
	// Update is called once per frame
	void Update () {
	}*/
}