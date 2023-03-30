using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrafficCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "Racer"){
            SceneManager.LoadScene("Arcade");
        }
    }
}
