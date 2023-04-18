using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeScript : MonoBehaviour
{
    public void CallArcadeTrack(int num) { 
        FlowManager.Instance.setModeArcade();
        Debug.Log("track" + num.ToString());
        FlowManager.Instance.SetTrack(num);
    }
}
