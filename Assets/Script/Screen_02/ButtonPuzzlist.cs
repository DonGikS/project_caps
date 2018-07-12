using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzlist : MonoBehaviour {

    public GameObject puzzleView;

	public void OnClickPuzzlist()
    {
        if(puzzleView.activeSelf == false)
        {
            puzzleView.SetActive(true);
        }
        else
        {
            puzzleView.SetActive(false);
        }
    }
}
