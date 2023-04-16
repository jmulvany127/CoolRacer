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
        //replayMenu = GameObject.FindGameObjectWithTag("replay");
        replayMenu.SetActive(false);

        // logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<score>();
        if (!FlowManager.Instance.Arcade) {
            time = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        }
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
        if (!FlowManager.Instance.Arcade) {
        //  float recordedScore = time.ClearTimer();
            time.continue_inc = true;
        }
        
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        
        int track = FlowManager.Instance.Track;
        switch (track)
        {
            case 1:
                SceneManager.LoadScene("level1"); 
                break;
            case 2:
                SceneManager.LoadScene("level2"); 
                break;
            case 3:
                SceneManager.LoadScene("level3"); 
                break;
            case 4:
                SceneManager.LoadScene("Arcade"); 
                break;
            case 5:
                SceneManager.LoadScene("Arcade2"); 
                break;
            case 6:
                SceneManager.LoadScene("Arcade3"); 
                break;
            default:
                break;
        }
    }

    public void GoToMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("mainmenu"); 
    }

    public void collision() {
        Debug.Log("Collided");
        handleEnd();
    }
    

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collided");
        if (other.gameObject.name == "Racer") {
            handleEnd();
        } 
    }

    private void handleEnd() {
        if(FlowManager.Instance.Track <= 3) {
            if (!FlowManager.Instance.Arcade) {
                UpdateSave.currentTime = time.ClearTimer();
            }
            //UpdateSave.currentScore = 0;        //UPDATE WHEN SCOREKEEPER IMPLEMENTED
        }
        else if(FlowManager.Instance.Track > 3){
            UpdateSave.currentTime = 0;
            //UpdateSave.currentScore = score;        //UPDATE WHEN SCOREKEEPER IMPLEMENTED
        }

        if (!FlowManager.Instance.Arcade) {
            time.continue_inc = false;
        }
        
        Time.timeScale = 0f;
        UpdateSave.usernameToGet = FlowManager.Instance.email;
        UpdateSave.UpdateDatabase();
        Debug.Log("enter menu");
        replayMenu.SetActive(true);
    }
}
