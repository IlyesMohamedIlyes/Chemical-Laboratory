using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WritePHPFile
{
    static int comp = 0;

    public static string Main (string fields, string tableName)
    {
        char gum = '"';
        string all = "";
        string[] fieldsS = fields.Split(", ".ToCharArray ());

        for (int i = 0; i < fieldsS.Length; i++)
        {
            if (fieldsS[i] != "")
            {
                fieldsS[i] = "$row [" + gum + fieldsS[i] + gum + "] . " + gum + " | " + gum + ".";
                all += fieldsS[i];
            }
        }
        all = all.Substring(0, all.Length - 4) + "<br>" + gum;


        string localhost = gum + "localhost" + gum + ";";
        string username = gum + "ilyes" + gum + ";";
        string password = gum + "ilyes" + gum + ";";
        string dbName = gum + "LaboratoryProject" + gum + ";";
        string conFailed = "if (!$conn) die (" + gum + "Connection failed. " + gum + ". mysqli_connect_error ());";
        string sqlQuery = gum + "SELECT " + fields + " FROM " + tableName + gum + ";";

        string[] lines = {"<?php",
                          "$servername = " + localhost,
                          "$username = " + username,
                          "$password = " + password,
                          "$dbName = " + dbName,
                          "$conn = new mysqli ($servername, $username, $password, $dbName);",
                          conFailed,
                          "$sql = " + sqlQuery,
                          "$result = mysqli_query ($conn, $sql);",
                          "if (mysqli_num_rows ($result) > 0)",
                          "while ($row = mysqli_fetch_assoc ($result))",
                          "echo " + all,
                          ";",
                          "?>"

        };

        System.IO.File.WriteAllLines(@"D:\xampp_1\htdocs\LaboratoryProject\CustomPHPFile_" + comp +".php", lines);
        
        comp++;

        return "CustomPHPFile_" + (comp-1) + ".php"; // return created file name.
    }
}
