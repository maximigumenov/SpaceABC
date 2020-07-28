using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

[System.Serializable]
public class FastScripting_Code
{
    public string path;

    [TextArea]
    public string usingMessage;
    public string nameClass;
    public string nameBaseClass;
    [TextArea]
    public string bodyClass;

    public void CreateCode() {

        string[] usingText = Regex.Split(usingMessage, @"\n");
        string[] bodyText = Regex.Split(bodyClass, @"\n");


        // string fileName = @"C:\Temp\Mahesh.txt";
        string fileName = Application.dataPath + "/" + nameClass + ".cs";
        Debug.LogError(fileName);
        using (StreamWriter outfile =
                  new StreamWriter(fileName))
        {

            for (int i = 0; i < usingText.Length; i++)
            {
                outfile.Write(usingText[i]);
            }

            outfile.WriteLine("");
            string _name = "public class " + nameClass;

            if (!string.IsNullOrEmpty(nameBaseClass))
            {
                _name += " : " + nameBaseClass;
            }

            outfile.WriteLine(_name);

            for (int i = 0; i < bodyText.Length; i++)
            {
                outfile.Write(bodyText[i]);
            }





        }//File written
    }
}
