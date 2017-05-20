using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BackToMain : MonoBehaviour {

    public void Back2Menu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
