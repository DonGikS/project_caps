using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInv : MonoBehaviour
{
    public GameObject puzzle;
    public void OnClickPuzzle()
    {
        if (puzzle.activeSelf == false)
        {
            puzzle.SetActive(true);
            gameObject.SetActive(false);
        }

    }
    // Use this for initialization
}
