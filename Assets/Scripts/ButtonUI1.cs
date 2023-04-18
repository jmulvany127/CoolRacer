using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI1 : MonoBehaviour
{
    // string varaible
    [SerializeField] private string selectTrack = "sel_track_1";

    public void TrackButton1()
    {
        SceneManager.LoadScene(selectTrack);
    }
}
