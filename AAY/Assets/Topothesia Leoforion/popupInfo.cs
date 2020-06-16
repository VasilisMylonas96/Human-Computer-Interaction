using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;


public class popupInfo : MonoBehaviour
{

    public GameObject panel;//Its your button
    bool flag =true;


    public void openPanel()
    {
        if (flag == true)
        {
            panel.SetActive(true);
            flag = false;
        }
        else
        {
            panel.SetActive(false);
            flag = true;
        }
    }

}