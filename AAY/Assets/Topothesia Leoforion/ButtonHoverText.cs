using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonHoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Detect if the Cursor starts to pass over the GameObject

    private GameObject hoverText = null;
    public Text text;

    public void Start()
    {
        //Text text = GetComponentInChildren<Text>();

        hoverText = text.gameObject;
        hoverText.SetActive(false);
    
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
      //  Debug.Log("Cursor Entering " + name + " GameObject");
        hoverText.SetActive(true);
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
      //  Debug.Log("Cursor Exiting " + name + " GameObject");
        hoverText.SetActive(false);
    }
}