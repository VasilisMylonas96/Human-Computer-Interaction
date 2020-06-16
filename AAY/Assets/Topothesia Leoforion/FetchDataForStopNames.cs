using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class FetchDataForStopNames : MonoBehaviour
{
    public Text stopName;

    void Start()
    {
        string file_path = Application.dataPath + "/StopNames1";
        StreamReader inp_stm = new StreamReader(file_path);

    
        string inp_ln = inp_stm.ReadLine();


        stopName.text = inp_ln;

        inp_stm.Close();
    }
}
