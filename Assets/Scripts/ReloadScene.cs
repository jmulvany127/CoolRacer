using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //You need to add this line manually. Without it SceneManager scripts won't work.


public class ReloadScene : MonoBehaviour {

    public score logic;
    public Timer time;
    public Controller car;

    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<score>();
        time = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        car = GameObject.FindGameObjectWithTag("Racer").GetComponent<Controller>();
    }



    private void OnTriggerEnter2D(Collider2D other) {
        float recordedScore = time.ClearTimer();
        logic.updateScore(recordedScore);
        car.ResetPosition();
        if (other.gameObject.name == "Racer") {
            other.transform.position = new Vector2(0,0);
        }
    }

}