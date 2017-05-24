using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectProfile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Back2Menu()
    {
        SceneManager.LoadScene("mainMenu");
    }
    public void go2AddProfile()
    {
        SceneManager.LoadScene("Addprofile");
    }
    public void Back2SelectProfile()
    {
        SceneManager.LoadScene("selectProfile");
    }
}
