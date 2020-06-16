using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QUESTIONMARK : MonoBehaviour
{
    public GameObject popquestionmark;
    public Button AGORA,LOGOBUTTON,BACKBUTTON;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pressedquestionmark() {
        popquestionmark.SetActive(true);
        AGORA.interactable = false;
        LOGOBUTTON.interactable = false;
        BACKBUTTON.interactable = false;
    }
    public void pressexit() {
        popquestionmark.SetActive(false);
        AGORA.interactable = true;
        LOGOBUTTON.interactable = true;
        BACKBUTTON.interactable = true;
    }

}
