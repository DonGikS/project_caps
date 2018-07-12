using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour {
    public static int remainingPieces = 16;
    public GameObject btnP;
    // Use this for initialization
    void Start () {
         btnP = GameObject.Find("btnPlay");
    }
	
	// Update is called once per frame
	void Update () {
		if (remainingPieces == 0)
        {
            Debug.Log("퍼즐이 다모였다.");
            
            btnP.SetActive(true);
        }
	}
}
