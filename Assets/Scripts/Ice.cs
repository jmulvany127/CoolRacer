using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    private Vector2 vel;

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.name == "Racer") {

            other.gameObject.GetComponent<Controller>().velocity *= 1.75f;
            other.gameObject.GetComponent<Controller>().isSpinning = true;
            other.gameObject.GetComponent<Controller>().spinTime = 0f;;
        }
    }
}
