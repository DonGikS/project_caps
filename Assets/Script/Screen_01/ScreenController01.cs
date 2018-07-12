using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//BinaryFormatter를 사용하기 위해서
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ScreenController01 : MonoBehaviour
{

    public List<GameObject> List;
    List<string> file_name = new List<string>();

    void Start()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("SampleClicked");
        for (int i = 0; i < go.Length; i++)
        {
            go[i].SetActive(false);
        }

        for (int i = 0; i < 6; i++)
        {
            List[i].SetActive(false);
        }

        string path;

        if (Application.platform == RuntimePlatform.Android)
        {
            path = Application.persistentDataPath + "/FileName.bin";
        }
        else
        {
            path = Application.dataPath + "/FileName.bin";
        }

        if (File.Exists(path))
        {
            // 파일명 읽어오기
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            List<string> temp = (List<string>)formatter.Deserialize(stream);

            int list_idx = 0;
            for (int i = temp.Count - 1; i > -1; i--)
            {
                List[list_idx].SetActive(true);
                List[list_idx].GetComponent<BtnList>().setText(temp[i]);
                list_idx++;
            }
        }
    }

    /*
    private GameObject popupView;

	// Use this for initialization
	void Start () {
        //gameObject.SetActiveRecursively(false);
        popupView = GameObject.FindGameObjectWithTag("PopupView");
        popupView.SetActive(false);
    }
	*/
}