using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;
using System.IO;

public class DropDown : MonoBehaviour
{
    internal int value;
    string content;
    public void HandleInputData(int val)
    {
        if (val == 0)
        {
            content = "Πανεπιστήμιο Μέσω Λεωφόρου Δωδώνης";
            Debug.Log("0");
            CreateText();
        }
        if (val == 1)
        {
            content = "Πανεπιστήμιο μέσω Ανατολής";
            Debug.Log("1");
            CreateText();
        }
        if (val == 2)
        {
            content = "Τ.Ε.Ι Μέσω Λεωφόρου Δωδώνης";
            Debug.Log("2");
            CreateText();
        }
    }



    void CreateText()
    {
        string path = "Assets/Resources/ProgramaKaiDromologia.txt";

        if (!File.Exists(path))
        {
            File.WriteAllText(path, "ProgramaKaiDromologia");
        }



        File.WriteAllText(path, content);

    }

}
