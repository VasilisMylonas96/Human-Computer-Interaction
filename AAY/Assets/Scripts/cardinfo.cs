using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class cardinfo : MonoBehaviour
{
    public LoadScene load;
    public Text ernumbercard, erpasscard;
    public GameObject window1, window2,TIMER;
    public InputField numbercard, passcard;
    public Dropdown month, year, CARD;
    List<String> list = new List<string>();
    string line, line1, currentusername, path , path1 , path4 , path3 ;
    string date, type;
    float price;
    string[] linecol;
    Boolean NUMBERFLAG, PASSFLAG,windowflag;
    int optioncards=-1;
    private Color color;
    List<Dropdown.OptionData> list1;
    public int countcard;
    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + "/CardFromUsers";
        path1 = Application.dataPath + "/holdcurrentname";
        path4 = Application.dataPath + "/SUCCESFULLBUY";
        path3 = Application.dataPath + "/tickets";
        System.IO.StreamReader file = new System.IO.StreamReader(path1);
        line1 = file.ReadLine();
        currentusername = line1;
        file.Close();
        if (File.Exists(path)) { 
            System.IO.StreamReader file1 = new System.IO.StreamReader(path);
            line = file1.ReadLine();
            while ((line = file1.ReadLine()) != null)
            {
                linecol = line.Split(',');
                if (linecol[0] == currentusername)
                {
                    windowflag = true;
                    list.Add(linecol[1]);
                    
                }

            }
            if (windowflag)
            {
                CARD.AddOptions(list);
                window2.SetActive(true);
                List<Dropdown.OptionData> list1 = CARD.options;
                CARD.value = list1.Count;
            }
            else {
                window1.SetActive(true);
            } 
        }
        else
        {
            window1.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void agora(int ticket)
    {
        if (PASSFLAG && NUMBERFLAG && month.value != 0 && year.value != 0|| CARD.value != 0)
        {
            date = DateTime.Now.ToString("M/d/yyyy");
            if (ticket == 1)
            {
                price = 1.5f;
                type = "Β'Ζώνη";
            }
            else if (ticket == 2)
            {
                price = 1.1f;
                type = "Κανονικό";
            }
            else if (ticket == 3)
            {
                price = 0.8f;
                type = "Φοιτητικό";
            }
            else
            {
                price = 0.6f;
                type = "Μαθητικό";
            }
            if (!File.Exists(path3))
            {
                using (StreamWriter save = File.CreateText(path3))
                {
                    save.WriteLine("UserName" + ' ' + "Type" + ' ' + "price" + ' ' + "date");
                    save.WriteLine(currentusername + ' ' + type + ' ' + price + ' ' + date);
                }
            }
            else
            {
                using (StreamWriter save = File.AppendText(path3))
                {
                    save.WriteLine(currentusername + ' ' + type + ' ' + price + ' ' + date);
                }
            }
            using (StreamWriter save = File.CreateText(path4))
            {
                save.WriteLine("OK");
            }
            TIMER.SetActive(true);
        }
    }
    public void addcard()
    {
        window2.SetActive(false);
        NUMBERFLAG = false;
        PASSFLAG = false;
        //CARD.value = 0;
        countcard = CARD.value;
        window1.SetActive(true);

    }
    public void checkcard() {
        if (numbercard.text.Length != 16)
        {
            numbercard.GetComponent<Image>().color = Color.red;
            ernumbercard.text = "Πρέπει να περιέχει 16 αριθμούς";
            NUMBERFLAG = false;
        }
        else
        {
            numbercard.GetComponent<Image>().color = Color.green;
            ernumbercard.text = "";
            NUMBERFLAG = true;
        }
        if (passcard.text.Length != 3)
        {
            passcard.GetComponent<Image>().color = Color.red;
            erpasscard.text = "Πρέπει να περιέχει 3 αριθμούς";

            PASSFLAG = false;
        }
        else
        {
            passcard.GetComponent<Image>().color = Color.green;
            erpasscard.text = "";
            PASSFLAG = true;
        }
        if (month.value == 0)
        {
            month.GetComponent<Image>().color = Color.red;
        }
        else
        {
            month.GetComponent<Image>().color = Color.green;
        }
        if (year.value == 0)
        {
            year.GetComponent<Image>().color = Color.red;
        }
        else
        {
            year.GetComponent<Image>().color = Color.green;
        }
    }
    public void savecard() {
      
        if (PASSFLAG && NUMBERFLAG && month.value != 0 && year.value != 0) 
        {
            if (!File.Exists(path))
            {
                using (StreamWriter save = File.CreateText(path))
                {
                    save.WriteLine("UserName" + "," + "Numbercard" + "," + "Passcard" + "," + "Month" + "," + "Year");
                    save.WriteLine(currentusername + ',' + numbercard.text + ',' + passcard.text + ',' + month.options[month.value].text + ',' + year.options[year.value].text);
                }
            }
            else
            {
                using (StreamWriter save = File.AppendText(path))
                {

                    save.WriteLine(currentusername + ',' + numbercard.text + ',' + passcard.text + ',' + month.options[month.value].text + ',' + year.options[year.value].text);
                }
            }
            window1.SetActive(false);
            window2.SetActive(true);
            list.Clear();
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            line = file.ReadLine();
            while ((line = file.ReadLine()) != null)
            {
                linecol = line.Split(',');
                if (linecol[0] == currentusername)
                {
                    optioncards = +1;
                    Debug.Log(linecol[1]);
                    list.Add(linecol[1]);
                }

            }
            file.Close();
            Debug.Log(list);
            CARD.AddOptions(list);
            list1 = CARD.options;
            CARD.value = list1.Count;
            countcard= list1.Count;
            numbercard.text = "";
            passcard.text = "";
            month.value = 0;
            year.value = 0;
            if (ColorUtility.TryParseHtmlString("#635E5E", out color))
            {
                numbercard.GetComponent<Image>().color = color;
                passcard.GetComponent<Image>().color = color;
                month.GetComponent<Image>().color = color;
                year.GetComponent<Image>().color = color;
            }

        } 
    }
    public void backtocard() {
        window1.SetActive(false);
        CARD.value = countcard;
        window2.SetActive(true);
    }
}
