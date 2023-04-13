using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayMenu : MonoBehaviour
{
    public score logic;
    public Timer time;
    public Controller car;
    public SaveHighscore UpdateSave;


    public GameObject replayMenu;
    // Start is called before the first frame update
    void Start() {
        replayMenu.SetActive(false);
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<score>();
        time = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        car = GameObject.FindGameObjectWithTag("Racer").GetComponent<Controller>();
        UpdateSave = GameObject.FindGameObjectWithTag("UpdateSave").GetComponent<SaveHighscore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame() {
          
        Time.timeScale = 1f;
        // float recordedScore = time.ClearTimer();
        // logic.updateScore(recordedScore);
        float recordedScore = time.ClearTimer();
        time.continue_inc = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("mainmenu"); 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Racer") {
            if(FlowManager.Instance.Track <= 3){
                UpdateSave.currentTime = time.ClearTimer();
                //UpdateSave.currentScore = 0;        //UPDATE WHEN SCOREKEEPER IMPLEMENTED
            }
            else if(FlowManager.Instance.Track > 3){
                UpdateSave.currentTime = 0;
                //UpdateSave.currentScore = score;        //UPDATE WHEN SCOREKEEPER IMPLEMENTED
            }
            Time.timeScale = 0f;
            time.continue_inc = false;
            UpdateSave.usernameToGet = FlowManager.Instance.email;
            UpdateSave.UpdateDatabase();
            replayMenu.SetActive(true);
        } 
    }
}
