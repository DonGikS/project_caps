using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main0 : MonoBehaviour {

    // global action state
    static public int MainState = 0;

    // alpha action
    private Transform titleImg;
    private SpriteRenderer sr;

    private Touch tempTouchs;
    private Vector3 touchedPos;

    private Vector2 mouseOriginPosition;
    private Vector2 mouseDragPosition;

    private Color originColor;

    private bool touchOn;

    // Use this for initialization
    void Start () {
        MainState = 0;
        titleImg = transform;
        sr = GetComponent<SpriteRenderer>();
        Color col = sr.color;
        // invisiable title image
        col.a = 0;
        sr.color = col;
    }

    // Update is called once per frame
    void Update()
    {
        if ( MainState == 0 )
        {
            TitleFadeOut();
        }
        else if( MainState > 0 )
        {
            MouseController();
        }
    }

    void MouseController()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseOriginPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            originColor = sr.color;
            Main0.MainState = 2;
        }
        else if (Input.GetMouseButton(0))
        {
            mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 temp;
            temp.x = System.Math.Abs(mouseOriginPosition.x - mouseDragPosition.x);
            temp.y = System.Math.Abs(mouseOriginPosition.y - mouseDragPosition.y);
            float dragDist = (float)System.Math.Sqrt((temp.x * temp.x) + (temp.y * temp.y)) / 150;
            if (dragDist > 1)
            {
                dragDist = 1.0f;
            }
            //Debug.Log(dragDist);

            // testing
            Color colTemp = originColor;
            colTemp.a = colTemp.a - dragDist;
            sr.color = colTemp;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if(sr.color.a < 0.3)
            {
                Main0.MainState = 3;
                // 씬전환
                SceneManager.LoadScene("Screen_00");
            }
            else
            {
                Main0.MainState = 1;
                Color colTemp = sr.color;
                colTemp.a = 1.0f;
                sr.color = colTemp;
            }
        }
    }

    void TitleFadeOut()
    {
        Color col = sr.color;
        col.a = col.a + (Time.deltaTime / 2);

        if (col.a > 1)
        {
            col.a = 1.0f;
            MainState = 1;
        }

        sr.color = col;
    }

}

/*
touchOn = false;

if (Input.touchCount > 0)
{    //터치가 1개 이상이면.
    for (int i = 0; i < Input.touchCount; i++)
    {
        tempTouchs = Input.GetTouch(i);
        if (tempTouchs.phase == TouchPhase.Began)
        {    //해당 터치가 시작됐다면.
            touchedPos = Camera.main.ScreenToWorldPoint(tempTouchs.position);//get world position.
            touchOn = true;

            // testing
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            Color temp = sr.color;
            temp.a = 0.0f;

            sr.color = temp;

            break;   //한 프레임(update)에는 하나만.
        }
    }

}
*/
