using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzSub : MonoBehaviour {

    private SpriteRenderer rend;

    private Vector2 mouseOriginPosition;
    private Vector2 mouseDragPosition;
    private Vector2 worldObjectPosition;

    private bool isDrag = false;
    private bool isMouseDown = false;

    // 0:up 1:down 2:left 3:right
    private int colSide = 0;
    private bool isCol = false;
    private Vector2 targetPos;

    private AudioSource sampleSource;

    private void OnMouseDown()
    {
        mouseOriginPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        isMouseDown = true;
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        isDrag = false;
        if (isCol)
        {
            attachPuzzle();
        }
        
    }

    // Drag On Puzzle
    private void OnMouseDrag()
    {
        mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        worldObjectPosition = Camera.main.ScreenToWorldPoint(mouseDragPosition);
        if (mouseOriginPosition != mouseDragPosition)
        {
            isDrag = true;
            GlowPuzz(false);
            //Debug.Log(worldObjectPosition);
            this.transform.position = worldObjectPosition;
        }
    }

    // Use this for initialization
    void Start () {
        rend = GetComponent<SpriteRenderer>();
        rend.material.shader = Shader.Find("Sprites/ShinyDefault");
    }

	// Update is called once per frame
	void Update () {
        GlowPuzz(true);
    }

    // _option = true : start glow
    // _option = false : end glow (reset)
    void GlowPuzz(bool _option)
    {
        if (_option)
        {
            if (isMouseDown == true && isDrag == false)
            {
                float shininess = rend.material.GetFloat("_ShineLocation") + Time.deltaTime*1.2f;
                if (shininess > 1)
                {
                    shininess = 0.0f;
                }
                rend.material.SetFloat("_ShineLocation", shininess);
                rend.material.SetFloat("_ShineWidth", 0.1f);
            }
        }
        else
        {
            rend.material.SetFloat("_ShineLocation", 0.0f);
            rend.material.SetFloat("_ShineWidth", 0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        isCol = true;
        //print(col.gameObject.transform.position);
        targetPos = col.gameObject.transform.position;
        colSide = checkCollisionSide(col);
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        isCol = false;
    }

    private int checkCollisionSide(Collision2D _col)
    {
        int result = -1;
        Vector2 colVector = _col.contacts[0].normal;
        if (colVector[0] == 0.0f && colVector[1] == 1.0f)
        {
            result = 0; // up side 
        }
        else if (colVector[0] == 0.0f && colVector[1] == -1.0f)
        {
            result = 1; // down side
        }
        else if (colVector[0] == -1.0f && colVector[1] == 0.0f)
        {
            result = 2; // left side
        }
        else if (colVector[0] == 1.0f && colVector[1] == 0.0f)
        {
            result = 3; // right side
        }
        return result;
    }

    private void attachPuzzle()
    {
        if(colSide == 0)
        {
            // x + 0 , y + 2.85
            Vector2 _attachPos = new Vector2(targetPos.x, (targetPos.y + 2.85f));
            this.gameObject.transform.position = _attachPos;
        }
        else if(colSide == 1)
        {
            // x + 0 , y - 2.83
            Vector2 _attachPos = new Vector2(targetPos.x, (targetPos.y - 2.83f));
            this.gameObject.transform.position = _attachPos;
        }
        else if(colSide == 2)
        {
            // x - 2.85 , y + 0
            Vector2 _attachPos = new Vector2((targetPos.x - 2.85f), targetPos.y);
            this.gameObject.transform.position = _attachPos;
        }
        else if(colSide == 3)
        {
            // x - 2.83 , y + 0
            Vector2 _attachPos = new Vector2((targetPos.x + 2.83f), targetPos.y);
            this.gameObject.transform.position = _attachPos;
        }
    }
}
