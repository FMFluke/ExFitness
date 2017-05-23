using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour {
    public GameObject sceneFabs;
    public Transform dirtContainer;
    public float blockSize = 32;
    public int blockPerRow = 27;
    public int numOfRow = 2;


    // Use this for initialization
    void Start () {
        GameObject a;
        //Horizantal floor
        for(int j = 0; j < numOfRow; j++)
        {
            for (int i = 0; i < blockPerRow; i++)
            {
                Vector3 pos = new Vector3(i * blockSize, j* blockSize, 0);
                a = Instantiate(sceneFabs, pos, Quaternion.identity);
                a.transform.SetParent(dirtContainer, true);
            }
        }
        //Stair 
        for (int i = 10; i < 20; i++)
        {
            Vector3 pos = new Vector3(i * blockSize, 2 * blockSize, 0);
            a = Instantiate(sceneFabs, pos, Quaternion.identity);
            a.transform.SetParent(dirtContainer, true);
        }
        for (int i = 12; i < 18; i++)
        {
            Vector3 pos = new Vector3(i * blockSize, 3 * blockSize, 0);
            a = Instantiate(sceneFabs, pos, Quaternion.identity);
            a.transform.SetParent(dirtContainer, true);
        }
        for (int i = 14; i < 16; i++)
        {
            Vector3 pos = new Vector3(i * blockSize, 4 * blockSize, 0);
            a = Instantiate(sceneFabs, pos, Quaternion.identity);
            a.transform.SetParent(dirtContainer, true);
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
