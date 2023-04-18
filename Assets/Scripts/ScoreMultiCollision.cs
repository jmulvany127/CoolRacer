using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiCollision : MonoBehaviour
{
    public ScoreKeeper display;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.name == "Racer"){
            FindObjectOfType<ScoreKeeper>().ScoreMulti();
            Destroy(this.gameObject);
        }
    }
}