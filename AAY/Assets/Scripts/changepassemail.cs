using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changepassemail : MonoBehaviour
{

    public GameObject sceene,rithm;
    
    float Step = 0.1f;
    float StepAngle = -36;
    float LOAD = 2f;
    float timefornextscene;
    float startTime;
    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > LOAD)
        {
            startTime = Time.time;
            sceene.SetActive(false);
            rithm.GetComponent<rithmiseis>().enabled = true;
            
        }
    }

}
