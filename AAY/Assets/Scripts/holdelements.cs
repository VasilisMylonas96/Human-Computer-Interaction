using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class holdelements : MonoBehaviour
{
    public InputField USER;
    string line, path ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        path = Application.dataPath + "/holdcurrentname";
    }

    public void Setusername()
    {
        using (StreamWriter save = File.CreateText(path))
        {
            save.WriteLine(USER.text);
        }
    }
}
