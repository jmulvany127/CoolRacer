using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //You need to add this line manually. Without it SceneManager scripts won't work.


public class ReloadScene : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Racer") {
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
        }
    }

}