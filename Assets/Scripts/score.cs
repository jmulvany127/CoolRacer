using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    public float playerScore;
    public Text shownScore;

    void Start()
    {
        playerScore = -1f;
    }


    [ContextMenu("Increment")]
    public void updateScore(float currentTime) {

        if (playerScore == -1f || currentTime < playerScore) {

            playerScore = currentTime;
            shownScore.text = currentTime.ToString();
        }

    }

}