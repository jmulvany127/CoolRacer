using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class launchGame : MonoBehaviour
{
    public void LoadLapScene() { 
        SceneManager.LoadScene("ControllerScene"); 
    }

    public void LoadMainMenuScene() {
        SceneManager.LoadScene("mainmenu"); 
    }

    public void LoadLoginScene() {
        SceneManager.LoadScene("loginScene"); 
    }

    public void LoadStatsScene() {
        SceneManager.LoadScene("statsScene"); 
    }

    public void LoadSelTrackArcade() {
        SceneManager.LoadScene("SelectTrackArcade"); 
    }

    public void LoadSelTrackTimeTrial() {
        SceneManager.LoadScene("track_menu_1"); 
    }

    public void LoadModeScene() {
        SceneManager.LoadScene("SelectModeScene"); 
    }
}
