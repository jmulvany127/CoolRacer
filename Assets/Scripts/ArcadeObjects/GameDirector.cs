using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    // Start is called before the first frame update
    public Racer racer;
    public int score;

    void start(){
        score = 0;
    }

    void update(){
        score += (int)(10 * Time.time);
    }

    public void GameOver(){

    }

    public void CoinScore(){

    }
}
