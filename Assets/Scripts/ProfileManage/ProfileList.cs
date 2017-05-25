using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class ProfileList : MonoBehaviour {
    public GameObject profileFabs;
    public Transform panel;
    public float profilePanelWidth = 336;
    public float profilePanelHeight = 86;
    private int profileCount = 10;
    private string connectionString;
    //private List<Profile> profList;

    // Use this for initialization
    void Start () {
        GameObject a;
        float profilePanelHeight = 86;
        RectTransform panelRT = panel.GetComponent<RectTransform>();
        Transform name;
        Text temp;
        //profList = new List<Profile>();
        profileCount = 1;

        connectionString = "URI=file:" + Application.dataPath + "/Exfitness.sqlite";
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand cmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT ID,NAME,WEIGHT,HEIGHT,GENDER FROM PLAYER";
                cmd.CommandText = sqlQuery;
                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Profile record = new Profile(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4)[0]);
                        Debug.Log("" + record.ID + " " + record.Name + " " + record.Weight + " " + record.Height + " " + record.Gender + " ");
                        panelRT.sizeDelta = new Vector2(panelRT.sizeDelta.x, profileCount * (profilePanelHeight) + 20);
                        Vector3 pos = new Vector3(0, -((profileCount - 1 + 0.5f) * profilePanelHeight), 1);
                        a = Instantiate(profileFabs, pos, Quaternion.identity);
                        a.transform.SetParent(panel.transform, false);
                        name = a.transform.Find("Name");
                        temp = name.transform.GetComponent<Text>();
                        temp.text = record.Name;

                        name = a.transform.Find("Weight");
                        temp = name.transform.GetComponent<Text>();
                        temp.text = "Weight: "+record.Weight.ToString()+" kg";

                        name = a.transform.Find("Height");
                        temp = name.transform.GetComponent<Text>();
                        temp.text = "Height: "+record.Height.ToString()+" cm";

                        name = a.transform.Find("Gender");
                        temp = name.transform.GetComponent<Text>();
                        temp.text = "Gender: "+record.Gender.ToString();

                        profileCount++;
                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }

        //panelRT.sizeDelta = new Vector2(panelRT.sizeDelta.x, profileCount*(profilePanelHeight)+20);
        //for (int i=0;i<profileCount;i++)
        //{
        //    panelRT.sizeDelta = new Vector2(panelRT.sizeDelta.x, profileCount * (profilePanelHeight) + 20);
        //    Vector3 pos = new Vector3(0, -((i + 0.5f) * profilePanelHeight), 1);
        //    a = Instantiate(profileFabs, pos, Quaternion.identity);
        //    a.transform.SetParent(panel.transform, false);
        //    name = a.transform.Find("Name");
        //    temp = name.transform.GetComponent<Text>();
        //    temp.text = "USER" + i;
        //    profileCount++;
        //    //Debug.Log("" + (i));
        //}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
