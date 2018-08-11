using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenController02 : MonoBehaviour
{
    public Camera camera;
    
    public GameObject puzzleData;
    public GameObject tutorialCanvas;
    public float dragTreshold;
    public float leftMargin;

    // target = click on Target
    private GameObject puzzleView;
    private GameObject target;
    private RaycastHit2D hit;
    private GameObject playView;

    // mouse position
    private Vector2 mouseDragPosition;
    private Vector2 worldDragPosition;
        //private Vector2 mouseOriginPosition;
    private Vector2 worldOriginPosition; 
    private Vector2 mouseOriginPosition;

    // Flag
    private bool isDrag;
    private bool createFlag;

    // Puzzle Controller
    PuzzleController pc;

    //
    List<Global.PuzzInfo> temp;

    // Use this for initialization
    void Start () {
        target = null;
        isDrag = false;
        createFlag = false;

        puzzleView = GameObject.FindGameObjectWithTag("PuzzleView");
        playView = GameObject.FindGameObjectWithTag("PlayView");
        //puzzleView.SetActive(false);
        playView.SetActive(false);

        tutorialCanvas.SetActive(true);
        tutorialCanvas.SendMessage("StartTutorial");
    }

    private void Update()
    {
        // 이미 퍼즐있으면 불러오기
        if (Global.loadPuzz_b == true)
        {
            Global.loadPuzz_b = false;

            temp = Global.GetPuzz();
            
            for (int i = 0; i < temp.Count; i++)
            {
                //UnityEngine.Object prefab = AssetDatabase.LoadAssetAtPath("Assets/prefab/puzz/" + temp[i].drum + ".prefab",typeof(GameObject));
                // UnityEngine.Object prefab = Resources.Load("prefab/" + temp[i].drum + ".prefab", typeof(GameObject));
                GameObject prefab = Resources.Load("prefab/" + temp[i].drum) as GameObject;
                //Debug.Log("prefab/" + temp[i].drum + ".prefab");
                //Debug.Log(prefab.name);
                GameObject clone = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
                clone.transform.position = new Vector3(temp[i].pos_x, temp[i].pos_y, 0);
            }
        }

        // Mouse Left Click ON
        if (Input.GetMouseButtonDown(0))
        {
            createFlag = false;
            GetRayObject();
        }
        // Mouse Left Click OFF
        else if(Input.GetMouseButtonUp(0))
        {
            isDrag = false;
            if (null == target) return;
            if (target.gameObject.tag.Equals("btnPuzzle"))
            {
                target = null;
                return;
            }

            pc = target.GetComponent<PuzzleController>();

            if (pc.GetIsCol())
            {
                if(pc.GetColTag().Equals("PuzzSub") || pc.GetColTag().Equals("PuzzStart"))
                {
                    target.SendMessage("AttachPuzzle");
                }
                else if(pc.GetColTag().Equals("btnTrash"))
                {
                    PuzzleData pd = puzzleData.GetComponent<PuzzleData>();
                    pd.DeletePuzzle(target);
                    Destroy(target);
                    target = null;
                }
            }
            target = null;
        }
        // Mouse Left Drag
        else if(Input.GetMouseButton(0))
        {
            // 퍼즐 새로 생성
            if (CheckTargetDrag("btnPuzzle", dragTreshold))
            {
                isDrag = true;
                CreatePuzzle();
            }

            // 퍼즐 옮김
            else if (CheckTargetDrag("PuzzSub", 0))
            {
                isDrag = true;
                DragOnPuzzle();
            }

            // 카메라 화면 옮김
            //if (CheckTargetDrag("background", 0))
            else if(EventSystem.current.IsPointerOverGameObject() == false)
            {
                isDrag = true;
                Debug.Log("카메라 옮김");
                CameraZoom();
            }
        }
    }

    private void CameraZoom()
    {
        mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //worldDragPosition = Camera.main.ScreenToWorldPoint(mouseDragPosition);

        if (mouseOriginPosition != mouseDragPosition)
        {
            float temp_x = mouseOriginPosition.x - mouseDragPosition.x;
            float temp_y = mouseOriginPosition.y - mouseDragPosition.y;

            if (Mathf.Abs(temp_x) > 10 && Mathf.Abs(temp_y) > 10)   // 상하좌우
            {
                float x = camera.transform.position.x + temp_x / 10.0f;
                if (x > 30) x = 30;
                else if (x < 0) x = 0;

                float y = camera.transform.position.y + temp_y / 10.0f;
                if (y > 0) y = 0;
                else if (y < -4.5) y = -5;


                camera.transform.position = new Vector3(x, y, -10);
                mouseOriginPosition = mouseDragPosition;
                //target.transform.position = worldDragPosition;
            }
            else if (Mathf.Abs(temp_x) > 10)
            { //좌우

                float x = camera.transform.position.x + temp_x / 10.0f;
                if (x > 30) x = 30;
                else if (x < 0) x = 0;

                camera.transform.position = new Vector3(x, camera.transform.position.y, -10);
                mouseOriginPosition = mouseDragPosition;
            }
            else if (Mathf.Abs(temp_y) > 10)
            {  // 상하
                float y = camera.transform.position.y + temp_y / 10.0f;
                if (y > 0) y = 0;
                else if (y < -4.5) y = -5;
                camera.transform.position = new Vector3(camera.transform.position.x, y, -10);
                mouseOriginPosition = mouseDragPosition;
            }

            /* 디버깅용(지우겠습니당)
            Debug.Log("mouseOriginPosition: " + mouseOriginPosition);
            Debug.Log("mouseDragPosition : " + mouseDragPosition);

            Debug.Log("camera.transform.position");
            Debug.Log("x" + camera.transform.position.x);
            Debug.Log("y" + camera.transform.position.y);
            */
        }
        
    }

    private void DragOnPuzzle()
    {
        //Debug.Log("get in DragOnPuzzle");
        mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        worldDragPosition = Camera.main.ScreenToWorldPoint(mouseDragPosition);
        if (mouseOriginPosition != mouseDragPosition)
        {
            //isDrag = true;
            //Debug.Log(worldObjectPosition);
            target.transform.position = worldDragPosition;
        }
    }

    private void CreatePuzzle()
    {
        Vector2 diff;
        Vector2 mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        diff.x = mpos.x - target.transform.position.x;
        diff.y = mpos.y - target.transform.position.x;

        //Debug.Log("mpos: " + mpos);
        //Debug.Log("target position: " + target.transform.position);

        // negative value = left move
        if (mpos.x <= leftMargin)
        {
            // Debug.Log("diff.x: " + diff.x);
            if(createFlag == false)
            {
                createFlag = true;
                ButtonPuzzle targetBP = target.GetComponent<ButtonPuzzle>();
                PuzzleData pd = puzzleData.GetComponent<PuzzleData>();
                target = Instantiate(targetBP.pfPuzz, mpos, Quaternion.identity);
                pd.AddPuzzle(target);

                worldOriginPosition = mpos;
            }
        }

        return;
    }

    private bool CheckTargetDrag(string targetTag, float threshold)
    {
        bool result = false;

        Vector2 diff;

        if ( null == target )
        {
            return false;
        }

        //Debug.Log("mousePosition: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //Debug.Log("targetPosition: " + target.transform.position);

        if (target.tag.Equals(targetTag))
        {
            Vector2 mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            diff.x = System.Math.Abs(mpos.x - worldOriginPosition.x);
            diff.y = System.Math.Abs(mpos.y - worldOriginPosition.y);

            if((diff.x >= threshold) &&
               (diff.y >= threshold))
            {
                result = true;
                //Debug.Log("diff: " + diff);
            }
        }

        return result;
    }

    /*
    private bool CheckTargetTag(string targetTag)
    {
        bool result = false;
        if((true == dragFlag) && (target.tag.Equals(targetTag)))
        {
            result = true;
        }
        return result;
    }
    */
    private void test()
    {
    }

    private void GetRayObject() 
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (null !=  hit.collider)
        { 
            //Debug.Log (hit.collider.name);
            //Debug.Log(hit.collider.tag);
            target = hit.collider.gameObject;
            worldOriginPosition = pos;
            mouseOriginPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        //object 아니어도 position 얻어오기
        mouseOriginPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }

    //
    public void deleteAllPuzz()
    {
        // 게임 오브젝트에서 지우고
        List<GameObject> puz = puzzleData.GetComponent<PuzzleData>().pfPuzzles;
        
        //puz.FindLast
        Destroy(puz[0].GetComponent<GameObject>());
        
        int idx = 0;
        while(puz[idx] != null && puz[idx] != null )
        {
            Destroy(puz[idx].GetComponent<GameObject>());
            idx++;
        }

    }

}
