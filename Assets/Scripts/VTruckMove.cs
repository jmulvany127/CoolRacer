using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VTruckMove : MonoBehaviour
{
    public int end_zone;
    // Start is called before the first frame update
    public float Speed = 15f;
    public float SpeedY = 5f;

    public float Y;


    void Start()
    {
        Y = Random.Range(0, 2);
        if (Y == 0) {
            transform.position = new Vector3(transform.position.x, 10f, transform.position.z);
            Vector3 newRotation = new Vector3(0, 0, 180);
            transform.eulerAngles = newRotation;
        }
        else if (Y == 1) {
            transform.position = new Vector3(transform.position.x, -10f, transform.position.z);
        }
        end_zone = -20;
        // if(Time.realtimeSinceStartup > 250){
        //     Speed = 30f;
        // }
        // else {
        //     Speed += 0.1f * Time.realtimeSinceStartup;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * Speed) * Time.deltaTime;

        if (Y == 0) {
            transform.position = transform.position + (Vector3.down * SpeedY) * Time.deltaTime;
            if(transform.position.y < -12){
                Destroy(gameObject);
            }
            
        }
        else if (Y == 1){
            transform.position = transform.position + (Vector3.up * SpeedY) * Time.deltaTime;
            if(transform.position.y > 12){
                Destroy(gameObject);
            }
        }

        if(transform.position.x < end_zone){
            Destroy(gameObject);
        }
    }
}
