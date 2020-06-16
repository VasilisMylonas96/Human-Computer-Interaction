using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Text.RegularExpressions;

public class Register : MonoBehaviour
{
    public holdelements hold;
    public Button Registers;
    public GameObject LoadNewScene;
    public InputField Passwordverify, Password, UserName, Email;
    public Text EmailText, NameText, Passtext;
    public Image red, orange, green, redverify;
    public Text Passtextverify;
    string path;
    string line;
    string[] linecol, linecolemail;
    string fullPath;
    int MinLength = 8;
    int MaxLength = 25;
    int MinLengthUsername = 3;
    Boolean errorMail, errorPass, errorPassconfir, errorName, Emailalreadyused = false;
    Boolean flagfirsttime;
    private Color color;
    public bool IsAlpha(string input)
    {
        return Regex.IsMatch(input, "^[a-zA-Z]+$");
    }
    public bool isNumber(string input)
    {
        return Regex.IsMatch(input, "^[0-9]+$");
    }
    public bool IsAlphaNumeric(string input)
    {
        return Regex.IsMatch(input, "^[a-zA-Z0-9]+$");
    }

    public bool IsAlphaNumericWithsimbols(string input)
    {
        return Regex.IsMatch(input, "^[a-zA-Z0-9_!@#$%^&*()-]+$");
    }

    public void passcheckverify() {

        Passtextverify.color = Color.white;
        if (Passwordverify.text == "")
        {
            Passwordverify.GetComponent<Image>().color = Color.red;
            Passtextverify.text = "O κωδικός επιβεβαίωσης απαιτείται";
            redverify.enabled = true;
            errorPassconfir = false;
        }
        else if (Passwordverify.text != Password.text)
        {
            Passwordverify.GetComponent<Image>().color = Color.red;
            redverify.enabled = true;
            Passtextverify.text = "Αυτοί οι κωδικοί πρόσβασης δεν ταιριάζουν. Δοκιμάστε ξανά";
            errorPassconfir = false;
        }
        else {
            if (ColorUtility.TryParseHtmlString("#11FF00", out color))
            {
                Passwordverify.GetComponent<Image>().color = color;
            }
            redverify.enabled = false;
            errorPassconfir = true;
            Passtextverify.text = "";
        }
    }
    public void passcheck() {

        
        Passtext.color = Color.white;
        if (Password.text.Length < MinLength)
        {
            Passtext.text = "Ο κωδικός πρέπει να περιέχει από " + MinLength + " μεχρι " + MaxLength + " χαρακτήρες";
            Password.GetComponent<Image>().color = Color.red;
            red.enabled = true;
            green.enabled = false;
            orange.enabled = false;

            errorPass = false;
        }
        else if (Password.text.Length > MaxLength)
        {
            Passtext.text = "Πρέπει να περιέχει το πολύ " + MaxLength + " χαρακτήρες ";
            Password.GetComponent<Image>().color = Color.red;
            red.enabled = true;
            green.enabled = false;
            orange.enabled = false;
            errorPass = false;
        }
        else if (isNumber(Password.text))
        {
            Passtext.text = "Ο κωδικός είναι κακός";
            Password.GetComponent<Image>().color = Color.red;
            red.enabled = true;
            green.enabled = false;
            orange.enabled = false;
            errorPass = false;
        }
        else if (IsAlphaNumeric(Password.text))
        {
            Passtext.text = "Ο κωδικός είναι μέτριος";
            if (ColorUtility.TryParseHtmlString("#FF9300", out color))
            {
                Password.GetComponent<Image>().color = color;
            }
            red.enabled = false;
            green.enabled = false;
            orange.enabled = true;
            errorPass = true;
        }
        else if (IsAlphaNumericWithsimbols(Password.text)) {
            red.enabled = false;
            orange.enabled = false;
            green.enabled = true;
            Passtext.text = "Ο κωδικός είναι καλός";
            if (ColorUtility.TryParseHtmlString("#11FF00", out color))
            {
                Password.GetComponent<Image>().color = color;
            }
            errorPass = true;
        }
    }

    public void save() {
        if (Password.text == "")
        {
            Passtext.text = "O κωδικός απαιτείται";

            Password.GetComponent<Image>().color = Color.red;
            errorPass = false;
            Passtext.color = Color.red;
            red.enabled = false;
            orange.enabled = false;
            green.enabled = false;
        }

        if (Passwordverify.text == "")
        {
            Passtextverify.text = "O κωδικός επιβεβαίωσης απαιτείται";
            Passwordverify.GetComponent<Image>().color = Color.red;
            Passtextverify.color = Color.red;
            redverify.enabled = false;
        }

        if (UserName.text == "")
        {
            NameText.text = "Το όνομα χρήστη απαιτείται";
            UserName.GetComponent<Image>().color = Color.red;
            errorName = false;
        }
        else if (UserName.text.Length < MinLengthUsername) {
            NameText.text = "Το όνομα χρήστη πρέπει να έχει τουλάχιστον " + MinLengthUsername+" χαρακτήρες";
            UserName.GetComponent<Image>().color = Color.red;
            errorName = false;
        }
        else
        {
            errorName = true;
            flagfirsttime = true;
            if (File.Exists(path))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    if (flagfirsttime)
                    {
                        flagfirsttime = false;
                    }
                    else
                    {
                        linecol = line.Split(',');
                        if (linecol[0] == UserName.text)
                        {
                            NameText.text = "Αυτό το όνομα χρήστη χρησιμοποιείται ήδη";
                            errorName = false;
                            break;
                        }
                    }
                }
                file.Close();
            }
            if (errorName)
            {
                NameText.text = "";
                if (ColorUtility.TryParseHtmlString("#11FF00", out color))
                {
                    UserName.GetComponent<Image>().color = color;
                }
            }
            
        }
        if (Email.text == "")
        {
            EmailText.text = "Το email Απαιτείται ";
            Email.GetComponent<Image>().color = Color.red;
        }
        else
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(Email.text);
                errorMail = true;
            }
            catch
            {
                EmailText.text = "Εισαγάγετε τη διεύθυνση email σας στη μορφή: Yourname @example.com ";
                Email.GetComponent<Image>().color = Color.red;
                errorMail = false;
            }
            char[] spearator = { '@', '.' };
            string[] email1 = Email.text.Split(spearator);
            Emailalreadyused = true;
            if (File.Exists(path))
            {
                
                flagfirsttime = true;
                System.IO.StreamReader file1 = new System.IO.StreamReader(path);
                while ((line = file1.ReadLine()) != null)
                {
                    
                    if (flagfirsttime)
                    {
                        flagfirsttime = false;
                    }
                    else
                    {
                        linecolemail = line.Split(',');
                        if (linecolemail[2] == Email.text)
                        {
                            Emailalreadyused = false;
                            break;
                        }
                    }
                }
                file1.Close();
            }
            if (email1.Length == 1 || email1.Length == 2)
            {
                EmailText.text = "Εισαγάγετε τη διεύθυνση email σας στη μορφή: Yourname @example.com ";
                Email.GetComponent<Image>().color = Color.red;
                errorMail = false;
            }
            else if (email1[2] != "com" && email1[2] != "gr" && email1[2] != "en" && email1[2] != "be" && email1[2] != "cy" && email1[2] != "fi" && email1[2] != "fr" && email1[2] != "de")
            {
                EmailText.text = "Εισαγάγετε τη διεύθυνση email σας στη μορφή: Yourname @example.com ";
                Email.GetComponent<Image>().color = Color.red;
                errorMail = false;
            }
            else if (!Emailalreadyused) {
                EmailText.text = "Αυτο το email υπάρχει ήδη ή χρησιμοποιείται από άλλον χρήστη";
                Email.GetComponent<Image>().color = Color.red;
                errorMail = false;
            }
            else
            {
                EmailText.text = "";
                if (ColorUtility.TryParseHtmlString("#11FF00", out color))
                {
                    Email.GetComponent<Image>().color = color;
                }
            }
            if (errorMail && errorPass && errorPassconfir&& errorName)
            {

                if (!File.Exists(path))
                {
                    using (StreamWriter save = File.CreateText(path))
                    {
                        save.WriteLine("UserName" + "," + "Password" + "," + "Email");
                        save.WriteLine(UserName.text + ',' + Password.text + ',' + Email.text );
                    }
                }
                else {
                    using (StreamWriter save = File.AppendText(path))
                    {
                        save.WriteLine(UserName.text + ',' + Password.text + ',' + Email.text);
                    }
                }
                hold.Setusername();
                LoadNewScene.SetActive(true);

                Registers.interactable = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + "/Users";
    }

    // Update is called once per frame
    void Update()
    {

    }
} 

