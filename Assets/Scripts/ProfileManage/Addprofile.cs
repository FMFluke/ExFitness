using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Addprofile : MonoBehaviour {
    public Text EnterWeight;
    public Text EnterHeight;
    public Text EnterName;
    public Text EnterGender;
    public Text ErrorMessage;
    public Text CompleteMessage;
    public GameObject PanelWarning;
    public GameObject PanelComplete;
    private string connectionString;
    public void InsertProfile(string name,int weight,int height,string gender)
    {
        connectionString = "URI=file:" + Application.dataPath + "/StreamingAssets/Exfitness.sqlite";
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand cmd = dbConnection.CreateCommand())
            {
                string sqlQuery = String.Format("INSERT INTO PLAYER (Name,Weight,Height,Gender) VALUES (\"{0}\",{1},{2},\"{3}\")",name,weight,height,gender) ;
                cmd.CommandText = sqlQuery;
                cmd.ExecuteScalar();
                dbConnection.Close();
            }
        }
    }
    public int Validate(int Weight,int Height) // Validating user input
    {
        if (Weight <= 0 && Height <= 0)
        {
            ErrorMessage.text = "Weight and Height Should not be negative or 0";
            return 1;
        }
        else if (Weight <= 0 || Weight >= 150)
        {
            ErrorMessage.text = "Weight Should not be negative or More than 150 kg";
            return 1;
        }
        else if (Height <= 0 || Height >= 200)
        {
            ErrorMessage.text = "Height Should not be negative or More than 200 cm";
            return 1;
        }
        else
        {
            CompleteMessage.text = "YOUR ADDING PROFILE COMPLETED !!";
            return 0;
        }

    }
    public void Enter()
    {
        int Weight, Height;
        if(EnterName.text == "" || EnterWeight.text == "" || EnterHeight.text == "" || EnterGender.text == "") //Loop for checking user fill input completely
        {
            ErrorMessage.text = "Please fill the form completely";
            PanelWarning.SetActive(true);
        }
        else
        {
            Weight = int.Parse(EnterWeight.text);
            Height = int.Parse(EnterHeight.text);
            int check = Validate(Weight, Height); //variable for checking
            if (check == 0)
            {
                InsertProfile(EnterName.text, Weight, Height, EnterGender.text);
                PanelComplete.SetActive(true); //Completion pop up shows
            }
            else
            {
                PanelWarning.SetActive(true);  //Warning pop up shows
            }
        }   
    }
    public void Popup()//Buttun to hide warning panel
    {
        PanelWarning.SetActive(false);
    }
    public void AddingComplte() //Buttton in Completion pop up to redirect to Select profile 
    {
        PanelComplete.SetActive(false);
        SceneManager.LoadScene("selectProfile");
    }
}
