using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI3 : MonoBehaviour
{
    // string varaible
    [SerializeField] private string selectTrack = "sel_track_3";

    public void TrackButton3()
    {
        SceneManager.LoadScene(selectTrack);
    }
}