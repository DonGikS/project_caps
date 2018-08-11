using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

//BinaryFormatter를 사용하기 위해서
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class btnNameSave : MonoBehaviour
{
    InputField _inputField;
    public GameObject PopupPanel;
    public GameObject PopupPanel2;
    public Text text;
    string path;

    // 버튼 클릭되면 
    public void OnClickNameSave()
    {
        // 파일 이름 받아오기->넘겨주기
        _inputField = GameObject.Find("InputField").GetComponent<InputField>();

        if (_inputField.text != null || _inputField.text != "")
        {
            // 파일명만 저장
            SaveFileName(_inputField.text);

            // 음원샘플만 저장
            //Combine();

            // GameObject 파일로 저장
            Global.SaveFile(_inputField.text, GameObject.Find("PuzzleData").GetComponent<PuzzleData>().returnList());

            _inputField.text = "";
            PopupPanel.SetActive(false);

            // 화면에 있는 모든 퍼즐도 없애기
            GameObject.Find("PuzzleData").GetComponent<PuzzleData>().resetList();

            // 저장되었다고 안내문구
            PopupPanel2.SetActive(true);
        }
        else
        {
            // 파일 이름 입력해달라고 안내문구
            PopupPanel.SetActive(true);
            text.text = "!노래 제목을 입력해주세요!";
        }

    }

    void SaveFileName(string _fileName)
    {
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
            stream.Close();
            // 파일명 추가
            temp.Add(_fileName);
            // 덮어쓰기
            stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, temp);
            stream.Close();
        }
        else
        {
            List<string> temp = new List<string>();
            temp.Add(_fileName);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, temp);
            stream.Close();
        }
    }

    AudioClip Combine(params AudioClip[] clips)
    {
        if (clips == null || clips.Length == 0)
            return null;

        int length = 0;
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i] == null)
                continue;

            length += clips[i].samples * clips[i].channels;
        }

        float[] data = new float[length];
        length = 0;
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i] == null)
                continue;

            float[] buffer = new float[clips[i].samples * clips[i].channels];
            clips[i].GetData(buffer, 0);
            //System.Buffer.BlockCopy(buffer, 0, data, length, buffer.Length);
            buffer.CopyTo(data, length);
            length += buffer.Length;
        }

        if (length == 0)
            return null;

        AudioClip result = AudioClip.Create("Combine", length / 2, 2, 44100, false, false);
        result.SetData(data, 0);

        return result;
    }

}