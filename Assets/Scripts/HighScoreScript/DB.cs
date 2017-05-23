using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DB : MonoBehaviour {
    private string connectionString;
    private List<HighScore> highScores = new List<HighScore>();
    public GameObject scoreprefab;
    public Transform scoreParent;
    public int HighscoreRank;
	// Use this for initialization
	void Start () {
        connectionString = "URI=file:" + Application.dataPath + "/Exfitness.sqlite";
        ShowScores();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void Getscore()
    {
        highScores.Clear();
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand cmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT ID,NAME,SCORE FROM PLAYER";
                cmd.CommandText = sqlQuery;
                using (IDataReader reader =cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        highScores.Add(new HighScore(reader.GetInt32(0),reader.GetString(1),reader.GetInt32(2)));
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
            highScores.Sort();
        }
    }
    private void ShowScores()
    {
        Getscore();
        for(int i=0; i<HighscoreRank;i++)
        {
            GameObject tmpObjec = Instantiate(scoreprefab);
            HighScore tmpScore = highScores[i];
            tmpObjec.GetComponent<HighScoreScript>().SetScore(tmpScore.Name, tmpScore.Score.ToString(), "#" + (i + 1).ToString());
            tmpObjec.transform.SetParent(scoreParent);
            tmpObjec.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        }

    }
 
}
