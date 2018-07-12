using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePuzzle : MonoBehaviour {

    public string pieceStatus;//퍼즐상태
    public bool checkPlacement;//바닥에 붙어있냐 아니냐 

    public KeyCode clickedPiece;//퍼즐을 눌렀는지 아닌지 아는 변수
	// Use this for initialization
	void Start () {
        pieceStatus = "pickup";
        checkPlacement = false;
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;
    }
	
	// Update is called once per frame
	void Update () {


        if(pieceStatus == "pickup")
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
            
        }
        if(pieceStatus == "dropit")
        {
            pieceStatus = "dropit";
            checkPlacement = true;
        }

        
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if((other.gameObject.name == gameObject.name) &&(checkPlacement == true))
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().sortingOrder = 5;
            transform.position = other.gameObject.transform.position;
            pieceStatus = "locked";
            checkPlacement = false;
            GameManger.remainingPieces -= 1;

        }
    }
    private void OnMouseDown()
    {
        pieceStatus = "pickup";
        checkPlacement = false;
        GetComponent<Renderer>().sortingOrder = 10;
    }
    private void OnMouseUp()
    {
        pieceStatus = "dropit";
        GetComponent<Renderer>().sortingOrder = 5;
        
    }
}
