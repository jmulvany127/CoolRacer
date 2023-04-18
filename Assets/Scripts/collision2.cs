using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision2 : MonoBehaviour
{
    public Rigidbody2D racer;

    private void OnCollisionStay2D(Collision2D collision)
    {
        //If the object hit is the player
        Vector2 position;
        position.x = 0;
        position.y = 0;

        //if (collision.gameObject.name == "Racer")
        //{
            Debug.Log("Object that collided with me: " + collision.gameObject.name);
            //collision.gameObject.GetComponent<Rigidbody2D>().MovePosition(position);


            racer.MovePosition(position);
            Debug.Log("Move");


            //collision.collider.GetComponent<RigidBody>();

            // collision.otherRigidbody.MovePosition(position);
        //}
    }
}
