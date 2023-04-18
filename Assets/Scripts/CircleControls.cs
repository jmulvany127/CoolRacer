using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleControls : MonoBehaviour {
    public Rigidbody2D rb;
    public float movespeed;

    void Start () {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update () {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, movespeed);

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, -movespeed);

        }

        // if (!(Input.GetKey(KeyCode.DownArrow)) && !(Input.GetKey(KeyCode.UpArrow)) && !(Input.GetKey(KeyCode.RightArrow)) && !(Input.GetKey(KeyCode.LeftArrow)))
        // {
        //     rb.velocity = new Vector2(0, 0);
        // }

        if (!(Input.GetKey(KeyCode.DownArrow)) && !(Input.GetKey(KeyCode.UpArrow)))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }

        if (!(Input.GetKey(KeyCode.RightArrow)) && !(Input.GetKey(KeyCode.LeftArrow)))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }
}
