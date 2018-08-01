using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScreenController02 : MonoBehaviour
{
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
        puzzleView.SetActive(false);
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
            //Debug.Log("cop: " + clickOriginPos);
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
            //Debug.Log("enter");
            if (CheckTargetDrag("btnPuzzle", dragTreshold))
            {
                isDrag = true;
                CreatePuzzle();
            }

            if (CheckTargetDrag("PuzzSub", 0))
            {
                isDrag = true;
                DragOnPuzzle();
            }
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
