using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class FetchDataProgramaKaiDromologia : MonoBehaviour
{
    public Text dromologio;

    void Start()
    {
        string file_path = "Assets/ProgramaKaiDromologia.txt";
        StreamReader inp_stm = new StreamReader(file_path);


        string inp_ln = inp_stm.ReadLine();
        Debug.Log("edw");
        Debug.Log(inp_ln);

        dromologio.text = inp_ln;

        inp_stm.Close();
    }
}
