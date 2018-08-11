using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BinaryFormatter를 사용하기 위해서
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class Global
{

    public static bool loadPuzz_b = false;
    public static string loadPuzz;
    public static List<string> file_name = new List<string>();
    public static List<PuzzInfo> PuzzList = new List<PuzzInfo>(); // 이걸 파일로 저장

    public static string filePath = Application.dataPath;


    [Serializable]
    public class PuzzInfo
    {
        /*
        public int id;
        public int drum;
        public int beat;
        */
        public string drum;
        public float pos_x;
        public float pos_y;
    };

    public static void SaveFile(String _FileName, List<GameObject> pfPuzzles) // _FileName 파일 저장이름
    {
        //PlayerPrefs.DeleteAll();

        //파일명 저장
        file_name.Add(_FileName);

        // 퍼즐 저장
        for (int i = 0; i < pfPuzzles.Count; i++)
        {
            PuzzList.Add(new PuzzInfo
            {
                // 퍼즐 이름 저장할때 (clone) 빼고 저장
                drum = pfPuzzles[i].name.Substring(0, 7),
                pos_x = pfPuzzles[i].transform.position.x,
                pos_y = pfPuzzles[i].transform.position.y
            });
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            filePath = Application.persistentDataPath + "/" + _FileName + ".bin";
        }
        else
        {
            filePath = Application.dataPath + "/" + _FileName + ".bin";
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(filePath, FileMode.Create);
        formatter.Serialize(stream, PuzzList);
        stream.Close();

        PuzzList.Clear(); //초기화
    }


    public static List<PuzzInfo> GetPuzz()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            filePath = Application.persistentDataPath + "/" + loadPuzz + ".bin";
        }
        else
        {
            filePath = Application.dataPath + "/" + loadPuzz + ".bin";
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(filePath, FileMode.Open);
        List<PuzzInfo> temp = (List<PuzzInfo>)formatter.Deserialize(stream);
        stream.Close();

        return temp;
    }
}