using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters;


public class PuzzleData : MonoBehaviour {


    //[Serializable]
    /*
    public class PuzzleInfo
    {
        public int id;
        public String pfName;
        public bool lockFlag;
        public int pos_x;
        public int pos_y;
    }
    */
   

    public List<GameObject> pfPuzzles;
    //private List<PuzzleInfo> puzzleInfos;
   

    public void AddPuzzle(GameObject item)
    {
        pfPuzzles.Add(item);
       
    }

    public void DeletePuzzle(GameObject item)
    {
        pfPuzzles.Remove(item);
        // 나중에하기
    }

    private void Start()
    {
        pfPuzzles = new List<GameObject>();
    }
    
    public List<GameObject> returnList()
    {
        return pfPuzzles;
    }

    public void resetList()
    {
        pfPuzzles.Clear();
    }
}
