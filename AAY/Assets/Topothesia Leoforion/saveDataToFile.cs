using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;


public class saveDataToFile : MonoBehaviour
{
    public string content;

    public void CreateText()
    {
        string path = Application.dataPath + "/StopNames1";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "stop names");
        }
        File.WriteAllText(path, content);        
    }
    public void CreateText1()
    {
        string path = Application.dataPath + "/StopNames";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "stop names");
        }
        File.WriteAllText(path, content);
    }

}
