using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class busBehavour : MonoBehaviour
{

    public Text data;
    string details;
    int minutes;
    int thesisAmea;

    // Start is called before the first frame update

    void Start()
    {

        calculateIRL();
        data.text = details;
    }


    void calculateIRL()
    {
        randomGenerator();


        printedText();
    }

    void printedText()
    {
        details = "Ώρα άφιξης: " + minutes + "'" + "\n" + "Θέσεις Α.Μ.Ε.Α: "+thesisAmea;
       // Debug.Log(details);
    }

    void randomGenerator()
    {


        minutes = Random.Range(0, 15);


        thesisAmea = Random.Range(0, 2);
    }
}
