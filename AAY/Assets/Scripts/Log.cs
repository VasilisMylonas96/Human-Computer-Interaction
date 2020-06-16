using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Color = UnityEngine.Color;

public class Log : MonoBehaviour
{
    public Button Loginb, Sign;
    public InputField UserName, Password;
    public Text error;
    string line, path;
    string[] linecol;
    public GameObject LoadNewScene;
    Boolean login,Passerror;
    private Color color;
    void Start()
    {
        path = Application.dataPath + "/Users";
    }
    public void Resetcolorpass() {
        if (ColorUtility.TryParseHtmlString("#635E5E", out color))
        {
            Password.GetComponent<Image>().color = color;
        }
    }
    public void Resetcoloruser()
    {
        if (ColorUtility.TryParseHtmlString("#635E5E", out color))
        {
            UserName.GetComponent<Image>().color = color;
        }
    }
    public void LoginifAllisok()
    {
        login = false;
        Passerror = false;
        System.IO.StreamReader file = new System.IO.StreamReader(path);
        line = file.ReadLine();
        while ((line = file.ReadLine()) != null)
        {
            linecol = line.Split(',');
            if (linecol[0] == UserName.text && linecol[1] == Password.text)
            {
                login = true;
                break;
            }
            else if (linecol[0] == UserName.text && linecol[1] != Password.text)
            {
                Passerror = true;
                break;
            }
        }
        file.Close();
        if (Passerror) {
            error.text = "Το όνομα χρήστη ή ο κωδικός δεν είναι σωστά";
            Password.GetComponent<Image>().color = Color.red;
            UserName.GetComponent<Image>().color = Color.red;
        }
        else if (login)
        {
            
            Loginb.interactable=false;
            Sign.interactable = false;
            error.text = "";
            if (ColorUtility.TryParseHtmlString("#635E5E", out color))
            {
                Password.GetComponent<Image>().color = color;
                UserName.GetComponent<Image>().color = color;
            }
            LoadNewScene.SetActive(true);


        }
        else {
            error.text = "Το όνομα χρήστη ή ο κωδικός δεν είναι σωστά";
            Password.GetComponent<Image>().color = Color.red;
            UserName.GetComponent<Image>().color = Color.red;
        }
    }
}


