using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class anazitisi : MonoBehaviour
{
    int first,second;
    public Dropdown B1, B2;
    public GameObject  im;
    public Text txt,txt2;
    public void getinput() {
        first = B1.value;
    }
    public void getinput2()
    {
        second = B2.value;
    }
    public void pressed() {
        im.SetActive(true);


        if (first == 0)
        {
            txt.text = "Προορισμοί Αστικού Ιωαννίνων Χειμερινό";
        }
        else {
            txt.text = "Προορισμοί Αστικού Ιωαννίνων θερινό";
        }
        if (second == 0)
        {
            txt2.text = "Πανεπιστήμιο Μέσω Λεωφόρου Δωδώνης";
        }
        else if (second == 1)
        {
            txt2.text = "Πανεπιστήμιο μέσω Ανατολής";
        }
        else {
            txt2.text = "Τ.Ε.Ι Μέσω Λεωφόρου Δωδώνης";
        }
        
    }
    public void back() {
        // v1.enabled = true;
        im.SetActive(false); ;
        B1.value=first;
        B2.value= second;
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
