using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeScript : MonoBehaviour
{
    public void CallArcade() { 
        FlowManager.Instance.setModeArcade();
    }

    public void CallTimeTrial() { 
        FlowManager.Instance.setModeTimeTrial();
    }
}
