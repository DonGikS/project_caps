using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController00 : MonoBehaviour {

    private Ray2D ray;
    private RaycastHit2D hit;

	// Use this for initialization
	void Start () {
        Screen.SetResolution(Screen.width, Screen.width / 9 * 16, true);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if (hit.collider != null)
            {
                Debug.Log("name : " + hit.collider.name);
                //PlayMakerFSM fsm = hit.collider.GetComponent<PlayMakerFSM>();
                //fsm.SendEvent("이벤트명");
            }
        }

    }
}
