using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        // if (other.gameObject.name == "Racer") {
        //     other.transform.position = new Vector2(0,0);
        // }

        if (other.gameObject.name == "Racer") {
            // Vector2 direction = 
            // other.transform.position = new Vector2(0,0);
            // other.attachedRigidbody.velocity


            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.down, ForceMode2D.Impulse);
        }
    }
}
