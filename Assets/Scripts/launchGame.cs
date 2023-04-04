using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class launchGame : MonoBehaviour
{
    public void LoadLapScene() { 
        SceneManager.LoadScene("ControllerScene"); 
    }

    public void LoadLoginScene() {
        //SceneManager.LoadScene("");
    }

    public void LoadStatsScene() {
        //SceneManager.LoadScene("");
    }
}
