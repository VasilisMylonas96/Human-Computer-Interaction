using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class buttongreenonmap : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button b1;
    private Color color;


    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        if (ColorUtility.TryParseHtmlString("#00FF11", out color))
        {
            b1.GetComponent<Image>().color = color;
        }
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (ColorUtility.TryParseHtmlString("#F5F5F5", out color))
        {
            b1.GetComponent<Image>().color = color;
        }
        //Output the following message with the GameObject's name
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
