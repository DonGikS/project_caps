using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveInv : MonoBehaviour, IDragHandler {
    public string checkInv;
    public Vector2 checkVec;
    // Use this for initialization
    RectTransform m_transform = null;
	void Start () {
        checkInv = "noneClick";
        m_transform = GetComponent<RectTransform>();
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        m_transform.position += new Vector3(eventData.delta.x, eventData.delta.y);
    }
    // Update is called once per frame
    void Update () {

       /* if (checkInv == "Click")
        {
            Vector2 lastVec = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 temp = Camera.main.ScreenToWorldPoint(new Vector2(lastVec.x - checkVec.x, 0));
            Vector2 objectVec = new Vector2(temp.x, gameObject.transform.position.y);
            transform.position = objectVec;
        }*/

    }
    /*
    public void OnMouseDown()
    {
        checkInv = "Click";
        Vector2 firstVec = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        checkVec = firstVec;
    }
    private void OnMouseUp()
    {
        checkInv = "noneClick";
    }*/
}
