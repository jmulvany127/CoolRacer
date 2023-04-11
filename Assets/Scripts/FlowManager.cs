using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowManager : MonoBehaviour
{
    public static FlowManager Instance;

    public string email;
    public bool Arcade = false;
    public bool TimeTrial = false;
    public int Track = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetEmail(string newEmail) {
        Instance.email = newEmail;
    }

    public void SetTrack(int newTrack) {
        Instance.Track = newTrack;
    }

    public void setModeArcade() {
        Instance.Arcade = true;
        Instance.TimeTrial = false;
    }

    public void setModeTimeTrial() {
        Instance.Arcade = false;
        Instance.TimeTrial = true;
    }
}
