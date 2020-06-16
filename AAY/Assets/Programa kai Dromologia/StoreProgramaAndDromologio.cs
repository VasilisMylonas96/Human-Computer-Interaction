using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;


public class StoreProgramaAndDromologio : MonoBehaviour
{
    public string content;

    public void CreateText()
    {
        string path = "Assets/Resources/ProgramaKaiDromologia.txt"; 

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "ProgramaKaiDromologia");
        }



        File.WriteAllText(path, content);

    }

}
