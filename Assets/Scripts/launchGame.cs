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

    public void LoadGameScene() {
        int track = FlowManager.Instance.Track;
        switch (track)
        {
            case 1:
                SceneManager.LoadScene("level1"); 
                break;
            case 2:
                SceneManager.LoadScene("level2"); 
                break;
            case 3:
                SceneManager.LoadScene("level3"); 
                break;
            case 4://todo add arcade
                break;
            case 5:
                break;
            case 6:
                break;
            default:
                break;
        }
    }
}
