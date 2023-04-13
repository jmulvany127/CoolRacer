using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackScript : MonoBehaviour
{
    public void CallTrack(int num) { 
        Debug.Log("track" + num.ToString());
        
        if (FlowManager.Instance.Arcade) {
            num = num + 3;
        }
        
        Debug.Log("now track" + num.ToString());

        FlowManager.Instance.SetTrack(num);
    }
}
