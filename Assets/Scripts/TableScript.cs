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
        float dummy = 47f;
        mode1track1.text = dummy.ToString();
        mode1track2.text = dummy.ToString();
        mode1track3.text = dummy.ToString();
        mode2track1.text = dummy.ToString();
        mode2track2.text = dummy.ToString();
        mode2track3.text = dummy.ToString();
    }
}
