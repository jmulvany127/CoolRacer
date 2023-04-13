using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mud : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.name == "Racer") {
            other.gameObject.GetComponent<Controller>().velocity *= 0.5f;
        }
    }

}
