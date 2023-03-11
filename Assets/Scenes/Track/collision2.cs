using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision2 : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        //If the object hit is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            
            Debug.Log("Hello");
        }
    }
}
