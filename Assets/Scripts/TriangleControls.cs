using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleControls : MonoBehaviour {
    public Rigidbody2D rb2;
    public float movespeed2;

    void Start () {
        rb2 = GetComponent<Rigidbody2D>();

    }

    void Update () {

        if (Input.GetKey(KeyCode.A))
        {
            rb2.velocity = new Vector2(-movespeed2, rb2.velocity.y);

        }

        if (Input.GetKey(KeyCode.D))
        {
            rb2.velocity = new Vector2(movespeed2, rb2.velocity.y);

        }

        if (Input.GetKey(KeyCode.W))
        {
            rb2.velocity = new Vector2(rb2.velocity.x, movespeed2);

        }

        if (Input.GetKey(KeyCode.S))
        {
            rb2.velocity = new Vector2(rb2.velocity.x, -movespeed2);

        }

        // if (!(Input.GetKey(KeyCode.DownArrow)) && !(Input.GetKey(KeyCode.UpArrow)) && !(Input.GetKey(KeyCode.RightArrow)) && !(Input.GetKey(KeyCode.LeftArrow)))
        // {
        //     rb.velocity = new Vector2(0, 0);
        // }

        if (!(Input.GetKey(KeyCode.S)) && !(Input.GetKey(KeyCode.W)))
        {
            rb2.velocity = new Vector2(rb2.velocity.x, 0);
        }

        if (!(Input.GetKey(KeyCode.D)) && !(Input.GetKey(KeyCode.A)))
        {
            rb2.velocity = new Vector2(0, rb2.velocity.y);
        }

    }
}
