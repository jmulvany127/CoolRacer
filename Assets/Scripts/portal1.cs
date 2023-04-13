using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal1 : MonoBehaviour
{
    
    public Vector3 newRespawnPoint;
    //wehn triggered by the racer change its position to the latestest respawn point and reset its velocity and angle 
    private void OnTriggerEnter2D(Collider2D other) {
        newRespawnPoint =  FindObjectOfType<Checkpoint1>().GetRespawn();
        if (other.gameObject.name == "Racer") {
            other.transform.position = newRespawnPoint;
            FindObjectOfType<Controller>().ResetPosition();
        }
    }

}
