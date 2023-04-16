using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TableScript : MonoBehaviour
{
    public TextMeshProUGUI mode1track1;
    public TextMeshProUGUI mode1track2;
    public TextMeshProUGUI mode1track3;
    public TextMeshProUGUI mode2track1;
    public TextMeshProUGUI mode2track2;
    public TextMeshProUGUI mode2track3;

    // Start is called before the first frame update
    void Start()
    {
        // todo change so that the database field for each is used
        
        // FlowManager.Instance.email // for user email
        FlowManager.Instance.checkEmail();
        FlowManager.Instance.SetTrack(0);
        if (FlowManager.Instance.email != "default@gmail.com") {
            CloudManager.Instance.statsTable(FlowManager.Instance.email);
            mode1track1.text = CloudManager.Instance.timeTrack1.ToString();
            mode1track2.text = CloudManager.Instance.timeTrack2.ToString();
            mode1track3.text = CloudManager.Instance.timeTrack3.ToString();
            mode2track1.text = CloudManager.Instance.arcadeTrack1.ToString();
            mode2track2.text = CloudManager.Instance.arcadeTrack2.ToString();
            mode2track3.text = CloudManager.Instance.arcadeTrack3.ToString();
        } else {
            mode1track1.text = "SCORES";
            mode1track2.text = "SCORES";
            mode1track3.text = "SCORES";
            mode2track1.text = "SCORES";
            mode2track2.text = "SCORES";
            mode2track3.text = "SCORES";
        }
    }
}
