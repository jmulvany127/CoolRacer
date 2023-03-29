using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{  
    //Respawn point is the origin if no checkpoints have been crossed
    public Vector3 respawnPoint = new Vector2(0,0);
    
    //if triggered by the racer change the respawn point to the current position 
    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Racer") {
            
            respawnPoint = transform.position;
        }
    }
    //this fucntion will return the respawn point when called
    public Vector3 GetRespawn(){
        return respawnPoint;
    }

}
