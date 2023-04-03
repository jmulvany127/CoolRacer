using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Racer") {
            other.transform.position = new Vector2(0,0);
        }
    }

}
