using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public int score;

    public int multiplier = 1;
    public float timer = 0;
    public float timeVal = 5;

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
        //Score multiplier
        if (timer > 0) {
            multiplier = 2;
            timer -= Time.deltaTime;
            shownScore.color = Color.red;
        }
        else {
            multiplier = 1;
            timer = 0;
            shownScore.color = Color.white;
        }

        score += ((int)(150 * Time.deltaTime * multiplier));
        shownScore.text = "Score: " + score.ToString();
    }
   
    public void CoinScore(){
        score += (100*multiplier);
    }
    public void DiamondScore(){
        score += (500*multiplier);
    }
    public void ScoreMulti() {
        timer += timeVal;
    }
    public enum TimerFormats
    {
        Whole,
        TenthDecimal,
        HundredthsDecimal
    }

    public int CLearScore() {
        int result = score;
        score = 0;
        return result;
    }
}
