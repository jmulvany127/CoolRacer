using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
// 
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.name == "Racer") {
            other.gameObject.GetComponent<Controller>().velocity *= 1.25f;
        }
    }

}
