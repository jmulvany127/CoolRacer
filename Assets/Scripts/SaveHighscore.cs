using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveHighscore : MonoBehaviour
{
    //currentTime needs to be set to the current time found in another script
    public float currentTime;
    //currentScore needs to be set to the current score found in another script
    public int currentScore;
    //public ScoreKeeper scoreKeeper;
    public float bestlap = float.MaxValue;
    private int highscore = 0;
    public string usernameToGet;// = FlowManager.Instance.email;
    //public Controller car;

    public static SaveHighscore Instance;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void loadData()
    {
        //load highscores and initialise
        //CloudManager.Instance.usernameToGet = usernameToGet;
        CloudManager firestore = GetComponent<CloudManager>();

        if (FlowManager.Instance.Track == 1)
        {
            bestlap = CloudManager.Instance.timeTrack1;
        }

        if (FlowManager.Instance.Track == 2)
        {
            bestlap = CloudManager.Instance.timeTrack2;
        }

        if (FlowManager.Instance.Track == 3)
        {
            bestlap = CloudManager.Instance.timeTrack3;
        }

        if (FlowManager.Instance.Track == 4)
        {
            highscore = CloudManager.Instance.arcadeTrack1;
        }

        if (FlowManager.Instance.Track == 5)
        {
            highscore = CloudManager.Instance.arcadeTrack2;
        }

        if (FlowManager.Instance.Track == 6)
        {
            highscore = CloudManager.Instance.arcadeTrack3;
        }
    }

    public void UpdateDatabase()
    {
        loadData();
        //if the current score is greater than the previous best score
        //update highscore and add it to database
        if (currentTime < bestlap)
        {
            CloudManager.Instance.UpdateHighscore(usernameToGet, currentTime, currentScore, FlowManager.Instance.Track);
        }
        if (currentScore > highscore)
        {
            CloudManager.Instance.UpdateHighscore(usernameToGet, currentTime, currentScore, FlowManager.Instance.Track);
        }
    }
}
