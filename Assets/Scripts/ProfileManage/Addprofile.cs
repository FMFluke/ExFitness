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
    private string connectionString;
    public void InsertProfile(string name,int weight,int height,string gender)
    {
        connectionString = "URI=file:" + Application.dataPath + "/Exfitness.sqlite";
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
    public void Enter()
    {
        int Weight = int.Parse(EnterWeight.text);
        int Height = int.Parse(EnterHeight.text);
        InsertProfile(EnterName.text, Weight, Height, EnterGender.text);
        SceneManager.LoadScene("selectProfile");
    }
}
