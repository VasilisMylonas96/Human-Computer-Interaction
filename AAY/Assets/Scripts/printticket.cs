using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
public class printticket : MonoBehaviour
{
    
    public Text typeeng, priceeng, hmeg, typenot, pricenot, hmnot,txt;
    public GameObject change,tick;
    public Dropdown egkura,miegkyra;
    string line, line1, usernamelog, path1 , path3 , path ;
    string[] linecol;
    int number, number1;
    List<String> listdrop = new List<string>();
    List<String> listdropnot = new List<string>();
    List<String> list = new List<string>();
    List<String> price = new List<string>();
    List<String> date = new List<string>();
    List<String> type = new List<string>();
    List<String> list1 = new List<string>();
    List<String> price1 = new List<string>();
    List<String> date1 = new List<string>();
    List<String> type1 = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        path1 = Application.dataPath + "/holdcurrentname";
        path3 = Application.dataPath + "/tickets";
        path = Application.dataPath + "/ticketschecked";
        if (File.Exists(path1))
        {
            System.IO.StreamReader file = new System.IO.StreamReader(path1);
            usernamelog = file.ReadLine();
            file.Close();
        }
        list.Add(" ");
        price.Add(" ");
        date.Add(" ");
        type.Add(" ");
        if (File.Exists(path3))
        {
            System.IO.StreamReader file1 = new System.IO.StreamReader(path3);
            line = file1.ReadLine();
            while ((line = file1.ReadLine()) != null)
            {
                linecol = line.Split(' ');
                if (linecol[0] == usernamelog)
                {
                    listdrop.Add(linecol[1]);
                    list.Add(linecol[1]);
                    price.Add(linecol[2]);
                    date.Add(linecol[3]);
                    type.Add(linecol[1]);
                }

            }
            egkura.AddOptions(listdrop);
            file1.Close();
        }

        list1.Add(" ");
        price1.Add(" ");
        date1.Add(" ");
        type1.Add(" ");
        if (File.Exists(path))
        {
            System.IO.StreamReader file1 = new System.IO.StreamReader(path);
            line = file1.ReadLine();
            while ((line = file1.ReadLine()) != null)
            {
                linecol = line.Split(' ');
                if (linecol[0] == usernamelog)
                {
                    listdropnot.Add(linecol[1]);
                    list1.Add(linecol[1]);
                    price1.Add(linecol[2]);
                    date1.Add(linecol[3]);
                    type1.Add(linecol[1]);
                }

            }
            miegkyra.AddOptions(listdropnot);
            file1.Close();
        }

    }
    public void choice() {
        number = egkura.value;
        number1 = miegkyra.value;
    }
    public void egkuraseter() {
       
        change.SetActive(true);
        txt.text = "Έγκυρο εισιτήριο";
        typenot.text = type[number];
        hmeg.text = date[number];
        priceeng.text = price[number] + "0€" ;
        tick.SetActive(false);

    }
    public void mheguraseter() {
       
        change.SetActive(true);
        txt.text = "Eπικυρωμένο εισιτήριο";
        typeeng.text = type1[number1];
        hmnot.text = date1[number1];
        pricenot.text = price1[number1]+ "0€";
        tick.SetActive(true);
    }
    public void back() {
        
        egkura.value = 0;
        miegkyra.value=0;
        change.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
