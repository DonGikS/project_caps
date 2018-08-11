using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPuzzlist : MonoBehaviour {

    public GameObject puzzleBox;


    Animator anim;
    bool isOpen = false;

    void Start()
    {
        anim = puzzleBox.GetComponent<Animator>();
    }
    
	public void OnClickPuzzlist()
    {
        if (isOpen)
        {
            //close the page
            StopCoroutine("ClosePage");
            StartCoroutine("ClosePage");
        }

        else
        {
            puzzleBox.SetActive(true);
            isOpen = true;
        }
        
    }
    

    IEnumerator ClosePage()
    {
        anim.SetBool("exit", true);

        yield return new WaitForSeconds(.15f);

        while (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1 || anim.IsInTransition(0))
        {
            yield return null;
        }

        anim.SetBool("exit", false);

        yield return new WaitForSeconds(.15f);

        isOpen = false;
        puzzleBox.SetActive(false);
    }
}
