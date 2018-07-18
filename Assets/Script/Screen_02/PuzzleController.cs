using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleController : MonoBehaviour
{
    private Vector2 mouseOriginPosition;
    private Vector2 mouseDragPosition;
    private Vector2 worldObjectPosition;
    
    private bool isDrag = false;
    private bool isMouseDown = false;

    // 0:up 1:down 2:left 3:right
    private int colSide = 0;
    private bool isCol = false;
    private string colTag;
    private Vector2 targetPos;

    private AudioSource sampleSource;

    private void Start()
    {
        Debug.Log("값가져옴");
       
    }
    /*
    private void OnMouseDown()
    {
        Debug.Log("마우스 다운");
        mouseOriginPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        isMouseDown = true;
        
    }

    private void OnMouseUp()
    {
        Debug.Log("마우스 뗏다");
        isMouseDown = false;
        isDrag = false;
        if (isCol)
        {
            AttachPuzzle();
        }
        isMouseDown = false;
        isDrag = false;

    }
    */
    //***************************************건들기전
    /*
    private void OnCollisionEnter2D(Collision2D col)
    {
        isCol = true;
        //print(col.gameObject.transform.position);
        //Debug.Log(col.gameObject.name);
        colTag = col.gameObject.tag;
        if(colTag.Equals("PuzzStart") ||
           colTag.Equals("PuzzSub"))
        {
            targetPos = col.gameObject.transform.position;
            colSide = CheckCollisionSide(col);
        }
        else if(colTag.Equals("PlayBar"))
        {
            sampleSource = this.gameObject.GetComponent<AudioSource>();
            sampleSource.PlayOneShot(sampleSource.clip);
        }
    }*/
    //************************************************************
    private void OnCollisionEnter2D(Collision2D col)
    {
        isCol = true;
        //print(col.gameObject.transform.position);
        //Debug.Log(col.gameObject.name);
        colTag = col.gameObject.tag;
        if (colTag.Equals("PuzzStart") ||
           colTag.Equals("PuzzSub"))
        {
            targetPos = col.gameObject.transform.position;
            colSide = CheckCollisionSide(col);
        }
        else if (colTag.Equals("PlayBar"))
        {
            sampleSource = this.gameObject.GetComponent<AudioSource>();
            sampleSource.PlayOneShot(sampleSource.clip);
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        isCol = false;
        colTag = null;
    }
    
    private int CheckCollisionSide(Collision2D _col)
    {
        int result = -1;
        Vector2 colVector = _col.contacts[0].normal;
        if (colVector[0] == 0.0f && colVector[1] >= 0.9f)
        {
            result = 0; // up side 
        }
        else if (colVector[0] == 0.0f && colVector[1] <= -0.9f)
        {
            result = 1; // down side
        }
        else if (colVector[0] <= -0.9f && colVector[1] == 0.0f)
        {
            result = 2; // left side
        }
        else if (colVector[0] >= 0.9f && colVector[1] == 0.0f)
        {
            result = 3; // right side
        }
        return result;
    }

    private void AttachPuzzle()
    {
        if (colSide == 0)
        {
            // x + 0 , y + 2.35
            Vector2 _attachPos = new Vector2(targetPos.x, (targetPos.y + 2.4f));
            this.gameObject.transform.position = _attachPos;
        }
        else if (colSide == 1)
        {
            // x + 0 , y - 2.35
            Vector2 _attachPos = new Vector2(targetPos.x, (targetPos.y - 2.4f));
            this.gameObject.transform.position = _attachPos;
        }
        else if (colSide == 2)
        {
            // x - 2.35 , y + 0
            Vector2 _attachPos = new Vector2((targetPos.x - 2.4f), targetPos.y);
            this.gameObject.transform.position = _attachPos;
        }
        else if (colSide == 3)
        {
            // x + 2.35 , y + 0
            Vector2 _attachPos = new Vector2((targetPos.x + 2.4f), targetPos.y);
            this.gameObject.transform.position = _attachPos;
        }
    }

    public bool GetIsCol()
    {
        // call by value로 수정요망
        return isCol;
    }

    public string GetColTag()
    {
        return colTag;
    }

    // Drag On Puzzle
    /*
    private void OnMouseDrag()
    {
        Debug.Log("마우스 드래그중");
        mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        worldObjectPosition = Camera.main.ScreenToWorldPoint(mouseDragPosition);
        if (mouseOriginPosition != mouseDragPosition)
        {
            isDrag = true;
            //Debug.Log(worldObjectPosition);
            this.transform.position = worldObjectPosition;
        }
    }
    */

    /*
    public void OnBeginDrag(PointerEventData eventData)
    {
        // 처음 위치 저장해둠
        mouseOriginPosition = this.transform.position;
        Debug.Log("터치 누름 : "+mouseOriginPosition);
    }

    public void OnDrag(PointerEventData eventData)
    {

        Debug.Log("터치 드래그중 ");
        // 퍼즐이 현재위치를 따라가도록 하기 위해서
        //mouseDragPosition = Input.mousePosition;
        //this.transform.position = mouseDragPosition;
    }


    public void OnEndDrag(PointerEventData eventData)
    {

        // 붙이러는 블럭 근처에 있을 때
        /*
        if (isCol)
        {
            AttachPuzzle();
        }
        // 마우스 땟을 때 아직 button menu panel에 있다면 -> 샘플 소리 플레이
        else
        {
        Debug.Log("터치 뗌");
        GetComponent<AudioSource>().Play();
        //worldObjectPosition
        //sampleSource = this.gameObject.AddComponent<AudioSource>();
        //  }
    }*/
}