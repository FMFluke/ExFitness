using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileList : MonoBehaviour {
    public GameObject profileFabs;
    public Transform panel;
    public float startX = 0;
    public float startY = 0;
    private int profileCount = 10;

	// Use this for initialization
	void Start () {
        GameObject a;
        float profilePanelWidth = 336;
        float profilePanelHeight = 86;
        startX = panel.position.x;
        startY = panel.position.y;
        RectTransform panelRT = panel.GetComponent<RectTransform>();
        Transform name;
        Text temp;
        panelRT.sizeDelta = new Vector2(panelRT.sizeDelta.x, profileCount*(profilePanelHeight)+20);
        for (int i=0;i<profileCount;i++)
        {
            Vector3 pos = new Vector3(startX + (profilePanelWidth*2.4f / 8f), startY - ((i + 1) * profilePanelHeight + (profilePanelHeight * 0.2f)), 1);
            a = Instantiate(profileFabs, pos, Quaternion.identity);
            a.transform.SetParent(panel.transform, false);
            name = a.transform.Find("Name");
            temp = name.transform.GetComponent<Text>();
            temp.text = "USER" + i;
            Debug.Log("" + (i));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
