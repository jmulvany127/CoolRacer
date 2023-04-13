using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public bool continue_inc;

    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    static public float currentTime;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timerFormats = new Dictionary<TimerFormats, string>();
    // Start is called before the first frame update
    void Start()
    {
        continue_inc = true;
        timerFormats.Add(TimerFormats.Whole, "0");
        timerFormats.Add(TimerFormats.TenthDecimal, "0.0");
        timerFormats.Add(TimerFormats.HundredthsDecimal, "0.00");
    }

    // Update is called once per frame
    void Update()
    {
        if (continue_inc) {
            currentTime += Time.deltaTime;
            if(hasLimit && currentTime <= timerLimit)
            {
                currentTime = timerLimit;
                SetTimerText();
                timerText.color = Color.red;
                enabled = false;
            }
            SetTimerText();
        }
    }

    public void SetTimerText()
    {
        timerText.text = hasFormat ? currentTime.ToString(timerFormats[format]) : currentTime.ToString();
    }

    public float ClearTimer() {
        float score = currentTime;
        currentTime = 0f;
        return score;
    }
}

public enum TimerFormats
{
    Whole,
    TenthDecimal,
    HundredthsDecimal
}