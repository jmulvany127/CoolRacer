using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI2 : MonoBehaviour
{
    // string varaible
    [SerializeField] private string selectTrack = "sel_track_2";

    public void TrackButton2()
    {
        SceneManager.LoadScene(selectTrack);
    }
}