using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class EpilogiLeoforioy : MonoBehaviour
{
    public Text dromologio;
    string busID;
    string kateuthinsi;
    public GameObject panel2;
    public GameObject panel1;

    void Start()
    {
        string file_path = Application.dataPath + "/StopNames";
        StreamReader inp_stm = new StreamReader(file_path);


        string inp_ln = inp_stm.ReadLine();
        Debug.Log("edw");
        Debug.Log(inp_ln);

        busID = inp_ln;

        setPanel();
        inp_stm.Close();
    }

    void setPanel()
    {
        if (busID == "16")
        {
            Debug.Log("edw");
            Debug.Log(busID);
            kateuthinsi = "Κατεύθυνση: Δικαστικό - Πανεπιστήμιο (22 στάσεις)";
            dromologio.text = kateuthinsi;
            panel1.SetActive(true);
        }
        if (busID == "17")
        {
            Debug.Log("edw");
            Debug.Log(busID);
            kateuthinsi = "Κατεύθυνση: Προς Πανεπιστήμιο Μέσω Ο.Α.Ε.Δ. - Τ.Ε.Ι. (21 στάσεις)";
            dromologio.text = kateuthinsi;
            panel2.SetActive(true);
        }
    }





}