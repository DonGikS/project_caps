using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleFrame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SpriteRenderer spr = GetComponent<SpriteRenderer>();

        Color color = spr.color;
        color.a = 0.3f;
        spr.color = color;
    }
}
