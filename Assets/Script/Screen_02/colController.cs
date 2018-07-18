using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colController : MonoBehaviour {
    public int colNum;
    public bool connectUpDonw, connectRightLeft, connectDownUp, connectLeftRight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (colNum == 1)
        {
            if (collision.collider.gameObject.name == "colDown")
            {
                Debug.Log("위아래1");
                connectUpDonw = true;
            } 
        }else if(colNum == 2)
        {
            if (collision.collider.gameObject.name == "colLeft")
            {
                Debug.Log("오른왼쪽2");
                connectRightLeft = true;
            }
        }
        else if(colNum == 3)
        {
            if (collision.collider.gameObject.name == "colUp")
            {
                Debug.Log("위아래3");
                connectDownUp = true;
            }
        }
        else if(colNum == 4)
        {
            if (collision.collider.gameObject.name == "colRight")
            {
                Debug.Log("오른왼쪽4");
                connectLeftRight = true;
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(connectUpDonw == true)
        {
            connectUpDonw = false;
        }else if(connectRightLeft == true)
        {
            connectRightLeft = false;
        }else if (connectDownUp == true)
        {
            connectDownUp = false;
        }else if(connectLeftRight == true)
        {
            connectLeftRight = false;
        }
    }
}
