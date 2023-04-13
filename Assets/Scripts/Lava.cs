using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Racer") {
        	//other.gameObject.GetComponent<SpriteRenderer>().sprite = other.gameObject.GetComponent<Controller>().CarSprites[1];
            other.gameObject.GetComponent<Controller>().keepBurning = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.name == "Racer") {
            other.gameObject.GetComponent<Controller>().velocity *= 0.85f;
            other.gameObject.GetComponent<Controller>().keepBurning = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "Racer") {
            other.gameObject.GetComponent<Controller>().keepBurning = true;
        }
    }
}
