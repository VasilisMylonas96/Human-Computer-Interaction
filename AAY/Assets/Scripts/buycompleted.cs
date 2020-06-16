using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class buycompleted : MonoBehaviour
{
    public GameObject image;
    float LOAD = 3f;
    float startTime;
    string path , line;
    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + "/SUCCESFULLBUY";
    }

    // Update is called once per frame
    void Update()
    {
        if (File.Exists(path))
        {

            System.IO.StreamReader file1 = new System.IO.StreamReader(path);
          
            while ((line = file1.ReadLine()) != null)
            {
                if (line != "")
                {
                    image.SetActive(true);
                    startTime = Time.time;
                    file1.Close();
                    using (StreamWriter save = File.CreateText(path))
                    {
                        save.WriteLine("");
                    }
                    break;
                }

            }
        }
        if (Time.time - startTime > LOAD)
        {
            image.SetActive(false);
        }
    }
}
