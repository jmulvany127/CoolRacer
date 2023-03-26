using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficMove : MonoBehaviour
{
    public float end_zone = -50f;
    // Start is called before the first frame update
    public float Speed = 5f;

    void Start()
    {
        if(Time.realtimeSinceStartup > 180){
            Speed = 20f;
        }
        else {
            Speed += 0.08f * Time.realtimeSinceStartup;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * Speed) * Time.deltaTime;

        if(transform.position.x < end_zone){
            Destroy(gameObject);
        }
    }
}
