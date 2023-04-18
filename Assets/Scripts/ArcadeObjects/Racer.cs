using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racer : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject.tag == "Traffic"){
            FindObjectOfType<GameDirector>().GameOver();
        }
        else if(collider.gameObject.name == "Coin"){
            FindObjectOfType<GameDirector>().CoinScore();
        }
    }
}
