using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class logoutopenscreen : MonoBehaviour
{
    public GameObject logoutwindow;
    public Button b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14, b15, b16, b17;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void logoutbutton()
    {
        b1.interactable = false;
        b2.interactable = false;
        b3.interactable = false;
        b4.interactable = false;
        b5.interactable = false;
        b6.interactable = false;
        b7.interactable = false;
        b8.interactable = false;
        b9.interactable = false;
        b10.interactable = false;
        b11.interactable = false;
        b12.interactable = false;
        b13.interactable = false;
        b14.interactable = false;
        b15.interactable = false;
        b16.interactable = false;
        b17.interactable = false;
        logoutwindow.SetActive(true);
    }
}
