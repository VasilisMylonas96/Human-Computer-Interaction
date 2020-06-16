using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text.RegularExpressions;
public class rithmiseis : MonoBehaviour
{
    string path1 , line,usernamelog, path;
    public GameObject changepasswindow,changemailwindow,succesfull,rithm, sceene;
    
    public InputField Passwordverify, Password, TWRINOSPASS, TWRINOSPASS1, Email;
    public Image red, orange, green, redverify;
    public Text Passtextverify, Passtext,CURRENTPASS, user, EmailText, CURRENTPASS1,edit1,edit2;
    Boolean errorMail, errorPassconfir = false, errorPasscur=false,errorPass=false, Emailalreadyused, flagfirsttime;
    int count, MaxLength = 25, MinLength = 8;

    private Color color;
    string[] linecol, linecolemail;
    // Start is called before the first frame update
    void Start()
    {
        path1 = Application.dataPath + "/holdcurrentname";
        path = Application.dataPath + "/Users";
        if (File.Exists(path1))
        {
            System.IO.StreamReader file = new System.IO.StreamReader(path1);
            usernamelog = file.ReadLine();
            file.Close();
        }
        user.text = usernamelog;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void back1() {
        changepasswindow.SetActive(false);
    }
    public void back2() {
        changemailwindow.SetActive(false);
    }
     public void changepass() {
        changepasswindow.SetActive(true);
    }
    public void changemail() {

        changemailwindow.SetActive(true);
    }
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

    public void passcheckverify()
    {

        Passtextverify.color = Color.white;
        if (Passwordverify.text == "")
        {
            Passwordverify.GetComponent<Image>().color = Color.red;
            Passtextverify.text = "Ο κωδικός επιβεβαίωσης απαιτείται";
            redverify.enabled = true;
            errorPassconfir = false;
        }
        else if (Passwordverify.text != Password.text)
        {
            Passwordverify.GetComponent<Image>().color = Color.red;
            redverify.enabled = true;
            Passtextverify.text = "Ο Κωδικός επιβεβαίωσης δεν είναι ίδιος με τον Νέο κωδικό.";
            errorPassconfir = false;
        }
        else
        {
            if (ColorUtility.TryParseHtmlString("#11FF00", out color))
            {
                Passwordverify.GetComponent<Image>().color = color;
            }
            redverify.enabled = false;
            errorPassconfir = true;
            Passtextverify.text = "";
        }
    }
    public void passcheck()
    {


        Passtext.color = Color.white;
        if (Password.text.Length < MinLength)
        {
            Passtext.text = "Ο Νέος κωδικός πρέπει να περιέχει από " + MinLength + " μέχρι " + MaxLength + " χαρακτήρες";
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
            Passtext.text = "Ο Νέος κωδικός είναι κακός";
            Password.GetComponent<Image>().color = Color.red;
            red.enabled = true;
            green.enabled = false;
            orange.enabled = false;
            errorPass = false;
        }
        else if (IsAlphaNumeric(Password.text))
        {
            Passtext.text = "Ο Νέος κωδικός είναι μέτριος";
            if (ColorUtility.TryParseHtmlString("#FF9300", out color))
            {
                Password.GetComponent<Image>().color = color;
            }
            red.enabled = false;
            green.enabled = false;
            orange.enabled = true;
            errorPass = true;
        }
        else if (IsAlphaNumericWithsimbols(Password.text))
        {
            red.enabled = false;
            orange.enabled = false;
            green.enabled = true;
            Passtext.text = "Ο Νέος κωδικός είναι καλός";
            if (ColorUtility.TryParseHtmlString("#11FF00", out color))
            {
                Password.GetComponent<Image>().color = color;
            }
            errorPass = true;
        }
    }
    public void changepassnow() {
        if (File.Exists(path))
        {
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            count = 0;
            file.ReadLine();
            while ((line = file.ReadLine()) != null) {
                count = count + 1;
                linecol = line.Split(',');
                if (linecol[0]== usernamelog) {
                    
                    break;
                }
            }
                
            file.Close();
        }
        if (TWRINOSPASS.text != linecol[1])
        {
            CURRENTPASS.text = "Ο Τρέχων κωδικός δεν είναι σωστός";
            errorPasscur = false;
            TWRINOSPASS.GetComponent<Image>().color = Color.red;
        }
        else {
            CURRENTPASS.text = " ";
            errorPasscur = true;
            TWRINOSPASS.GetComponent<Image>().color = Color.green;
        }
        if (Password.text == "")
        {
            Passtext.text = "Ο νέος κωδικός απαιτείται";

            Password.GetComponent<Image>().color = Color.red;
            errorPass = false;
            Passtext.color = Color.red;
            red.enabled = false;
            orange.enabled = false;
            green.enabled = false;
        }

        if (Passwordverify.text == "")
        {
            Passtextverify.text = "Ο κωδικός επιβεβαίωσης απαιτείται";
            Passwordverify.GetComponent<Image>().color = Color.red;
            Passtextverify.color = Color.red;
            redverify.enabled = false;
        }
        if (errorPass && errorPassconfir && errorPasscur)
        {
            string[] lines = File.ReadAllLines(path);
            using (StreamWriter save = File.CreateText(path))
            {
                save.WriteLine("UserName" + "," + "Password" + "," + "Email");
                for (int currentLine = 1; currentLine < lines.Length; ++currentLine)
                {
                    if (currentLine == count)
                    {
                        linecol = lines[count].Split(',');
                        save.WriteLine(linecol[0] + "," + Password.text + "," + linecol[2]);
                    }
                    else
                    {
                        save.WriteLine(lines[currentLine]);
                    }
                }
                    
            }
            changepasswindow.SetActive(false);
            edit1.text = "Ο κωδικός ενημερώθηκε ";
            edit2.text = "O κωδικός πρόσβασής σας έχει αλλάξει με επιτυχία";
            succesfull.SetActive(true);
        }
    }
    public void resetpeida() {
        green.enabled = false;
        orange.enabled = false;
        red.enabled = false;
        redverify.enabled = false;
        Passtextverify.text = "";
        Passtext.text = "";
        Password.text = "";
        CURRENTPASS.text = "";
        CURRENTPASS1.text = "";
        EmailText.text = "";
        TWRINOSPASS1.text = "";
        TWRINOSPASS.text="";
        Email.text = "";
        errorPassconfir = false;
        errorPasscur = false;
        errorPass = false;
        Emailalreadyused = false;
        errorMail = false;

        if (ColorUtility.TryParseHtmlString("#635E5E", out color))
        {
            Passwordverify.GetComponent<Image>().color = color;
            Password.GetComponent<Image>().color = color;
            TWRINOSPASS.GetComponent<Image>().color = color;
            TWRINOSPASS1.GetComponent<Image>().color = color;
            Email.GetComponent<Image>().color = color;
        }
       
    }
    public void changeemailinfile()
    {
        if (File.Exists(path))
        {
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            count = 0;
            file.ReadLine();
            while ((line = file.ReadLine()) != null)
            {
                count = count + 1;
                linecol = line.Split(',');
                if (linecol[0] == usernamelog)
                {

                    break;
                }
            }

            file.Close();
        }
        if (TWRINOSPASS1.text != linecol[1])
        {
            CURRENTPASS1.text = "Ο Τρέχων κωδικός δεν είναι σωστός";
            errorPasscur = false;
            TWRINOSPASS1.GetComponent<Image>().color = Color.red;
        }
        else
        {
            CURRENTPASS1.text = " ";
            errorPasscur = true;
            TWRINOSPASS1.GetComponent<Image>().color = Color.green;
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
            else if (!Emailalreadyused)
            {
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
        }
        if (errorMail&& errorPasscur) {
            string[] lines = File.ReadAllLines(path);
            using (StreamWriter save = File.CreateText(path))
            {
                save.WriteLine("UserName" + "," + "Password" + "," + "Email");
                for (int currentLine = 1; currentLine < lines.Length; ++currentLine)
                {
                    if (currentLine == count)
                    {
                        linecol = lines[count].Split(',');
                        save.WriteLine(linecol[0] + "," + linecol[1] + "," + Email.text);                    }
                    else
                    {
                        save.WriteLine(lines[currentLine]);
                    }
                }

            }
            changemailwindow.SetActive(false);
            edit1.text = "Tο email σας ενημερώθηκε ";
            edit2.text = "Tο email σας άλλαξε με επιτυχία σε"+"\n"+ Email.text;
            succesfull.SetActive(true);
            rithm.GetComponent<rithmiseis>().enabled = false;
        }
    }

}
