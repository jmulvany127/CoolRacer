using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayMenu : MonoBehaviour
{
    public score logic;
    public Timer time;
    public Controller car;


    public GameObject replayMenu;
    // Start is called before the first frame update
    void Start() {
        replayMenu.SetActive(false);
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<score>();
        time = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        car = GameObject.FindGameObjectWithTag("Racer").GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame() {
          
        Time.timeScale = 1f;
        float recordedScore = time.ClearTimer();
        logic.updateScore(recordedScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("mainmenu"); 
    }

    private void OnTriggerEnter2D(Collider2D other) {
        replayMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
