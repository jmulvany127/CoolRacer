using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public int score;

    [Header("Component")]
    public TextMeshProUGUI shownScore;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timerFormats = new Dictionary<TimerFormats, string>();
    // Start is called before the first frame update
    void Start()
    {
        score = 0;  
        timerFormats.Add(TimerFormats.Whole, "0");
        timerFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timerFormats.Add(TimerFormats.HundredthsDecimal, "0.00");
    }

    // Update is called once per frame
    void Update()
    {
        score += ((int)(150 * Time.deltaTime));
        shownScore.text = "Score: " + score.ToString();
    }
    
    public void CoinScore(){
        score += 100;
    }
    public enum TimerFormats
    {
        Whole,
        TenthDecimal,
        HundredthsDecimal
    }
}
