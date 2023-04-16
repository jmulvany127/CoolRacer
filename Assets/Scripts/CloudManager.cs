using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using UnityEngine.UI;

public class CloudManager : MonoBehaviour
{
    FirebaseFirestore db;
    Dictionary<string, object> user;

    public int arcadeTrack1;
    public int arcadeTrack2;
    public int arcadeTrack3;
    public float timeTrack1;
    public float timeTrack2;
    public float timeTrack3;
    public string username;// = FlowManager.Instance.email;
    //public string usernameToGet;// = FlowManager.Instance.email;

    public static CloudManager Instance;

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
        //FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>{
        //  FirebaseApp.Create();
        InitializeFirebaseFirestore();
        //});

        //readData();
    }

    void InitializeFirebaseFirestore()
    {
        db = FirebaseFirestore.DefaultInstance;
    }

    //this function saves a username, timeTrial, and arcadeScore to the database
    //to be called only when register is used to create a document for that user
    //when calling in register, set arcade score to 0 and timetrials to float.MaxValue
    public void SaveData()
    {
        timeTrack1 = float.MaxValue;
        timeTrack2 = float.MaxValue;
        timeTrack3 = float.MaxValue;
        arcadeTrack1 = 0;
        arcadeTrack2 = 0;
        arcadeTrack3 = 0;

        user = new Dictionary<string, object>
        {
            {"Username", username},
            {"Arcade Track 1", arcadeTrack1},
            {"Arcade Track 2", arcadeTrack2},
            {"Arcade Track 3", arcadeTrack3},
            {"Time Track 1", timeTrack1},
            {"Time Track 2", timeTrack2},
            {"Time Track 3", timeTrack3},
        };
        db.Collection("Users").Document(username).SetAsync(user).ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Successfully added text to database");
            }
            else
            {
                Debug.Log("Save not succesful");
            }
        });

    }

    //this function is used to load data from firestore
    //required when comparing lap times and arcadeScores
    //set username from the other script
    public void readData(string GivenUsername)
    {
        db.Collection("Users").Document(GivenUsername).GetSnapshotAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DocumentSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    user = snapshot.ToDictionary();
                    foreach (KeyValuePair<string, object> pair in user)
                    {
                        if (pair.Key == "Time Track 1")
                        {
                            timeTrack1 = float.Parse(pair.Value.ToString());
                            Debug.Log("track 1" + timeTrack1.ToString());
                        }

                        else if (pair.Key == "Time Track 2")
                        {
                            timeTrack2 = float.Parse(pair.Value.ToString());
                            Debug.Log("track 2" + timeTrack2.ToString());
                        }

                        else if (pair.Key == "Time Track 3")
                        {
                            timeTrack3 = float.Parse(pair.Value.ToString());
                            Debug.Log("track 3" + timeTrack3.ToString());
                        }

                        else if (pair.Key == "Arcade Track 1")
                        {
                            arcadeTrack1 = int.Parse(pair.Value.ToString());
                            Debug.Log("track 4" + arcadeTrack1.ToString());
                        }

                        else if (pair.Key == "Arcade Track 2")
                        {
                            arcadeTrack2 = int.Parse(pair.Value.ToString());
                            Debug.Log("track 5" + arcadeTrack2.ToString());
                        }

                        else if (pair.Key == "Arcade Track 3")
                        {
                            arcadeTrack3 = int.Parse(pair.Value.ToString());
                            Debug.Log("track 6" + arcadeTrack3.ToString());
                        }
                    }
                }
            }
        });
    }



    //call this at the finish line
    public void UpdateHighscore(string GivenUsername, float newRecord, int highscore, int trackMode)
    {
        readData(GivenUsername);
        // Save time trial track 1
        if (trackMode == 1)
        {
            Dictionary<string, object> update = new Dictionary<string, object>
            {
                {"Time Track 1", newRecord}
            };

            db.Collection("Users").Document(GivenUsername).UpdateAsync(update).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("Track 1 fastest lap added to database!");
                }
                else
                {
                    Debug.Log("Save Unsuccessful!");
                }
            });
        }


        // Save time trial track 2
        if (trackMode == 2)
        {
            Dictionary<string, object> update = new Dictionary<string, object>
            {
                {"Time Track 2", newRecord}
            };

            db.Collection("Users").Document(GivenUsername).UpdateAsync(update).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("Track 2 fastest lap added to database!");
                }
                else
                {
                    Debug.Log("Save Unsuccessful!");
                }
            });
        }


        // Save time trial track 3
        if (trackMode == 3)
        {
            Dictionary<string, object> update = new Dictionary<string, object>
            {
                {"Time Track 3", newRecord}
            };

            db.Collection("Users").Document(GivenUsername).UpdateAsync(update).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("Track 3 fastest lap added to database!");
                }
                else
                {
                    Debug.Log("Save Unsuccessful!");
                }
            });
        }


        // Save arcade track 1
        if (trackMode == 4)
        {
            Dictionary<string, object> update = new Dictionary<string, object>
            {
                {"Arcade Track 1", highscore}
            };

            db.Collection("Users").Document(GivenUsername).UpdateAsync(update).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("Track 1 highscore added to database!");
                }
                else
                {
                    Debug.Log("Save Unsuccessful!");
                }
            });
        }


        // Save arcade track 2
        if (trackMode == 5)
        {
            Dictionary<string, object> update = new Dictionary<string, object>
            {
                {"Arcade Track 2", highscore}
            };

            db.Collection("Users").Document(GivenUsername).UpdateAsync(update).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("Track 2 highscore added to database!");
                }
                else
                {
                    Debug.Log("Save Unsuccessful!");
                }
            });
        }


        // Save arcade track 3
        if (trackMode == 6)
        {
            Dictionary<string, object> update = new Dictionary<string, object>
            {
                {"Arcade Track 3", highscore}
            };

            db.Collection("Users").Document(GivenUsername).UpdateAsync(update).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    Debug.Log("Track 3 highscore added to database!");
                }
                else
                {
                    Debug.Log("Save Unsuccessful!");
                }
            });
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void statsTable(string GivenUsername) {
        readData(GivenUsername);
    }
}
