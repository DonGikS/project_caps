using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{
    public GameObject pfPuzz;

    private AudioSource sampleSource;

    /*
    public void OnClickButtonPuzzle()
    {
        //sampleSource.Play();
        GetComponent<AudioSource>().Play();
    }*/

    private void OnMouseDown()
    {
        //mouseOriginPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //isMouseDown = true;
        //Debug.Log("아무데나 클릭해도 읽을 수 있는가?");
        GetComponent<AudioSource>().Play();
    }


    void Start()
    {
        sampleSource = this.gameObject.AddComponent<AudioSource>();
    }
}
