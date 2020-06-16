using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class TIMERTICKET : MonoBehaviour
{
    public Button B1, B2, B3,B4;
    public RectTransform mainIconcycle;
    float Step = 0.1f;
    float StepAngle = -36;
    float LOAD = 2f;
    float timefornextscene;
    float startTime;
    public LoadScene LoadNewScene;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        timefornextscene = Time.time;
        B1.interactable=false;
        B2.interactable = false;
        B3.interactable = false;
        B4.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime >= Step)
        {
            Vector3 iconAngle = mainIconcycle.localEulerAngles;
            iconAngle.z += StepAngle;

            mainIconcycle.localEulerAngles = iconAngle;

            startTime = Time.time;
        }
        if (Time.time - timefornextscene > LOAD)
        {
            LoadNewScene.SceneLoader(4);
        }
    }

}