using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficMove : MonoBehaviour
{
    public int end_zone;
    // Start is called before the first frame update
    public float Speed = 5f;

    void Start()
    {
        end_zone = -20;
        if(Time.timeSinceLevelLoad > 250){
            Speed = 30f;
        }
        else {
            Speed += 0.1f * Time.timeSinceLevelLoad;
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
