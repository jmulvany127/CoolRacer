using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    //public Transform followTransform;

    public Transform followTransform0;
    public Transform followTransform1;
    public int player_flag;

    void Start () {
        int player_flag = 0;

    }

    

    // Update is called once per frame
    void Update()
    {   
        //For two objects, pressing key K switches camera following between the two objects
        if (Input.GetKeyDown(KeyCode.K)) {
            if (player_flag == 0) {
                player_flag = 1;
            }
            else {
                player_flag = 0;
            }
        }

        if (player_flag == 0) {
            this.transform.position = new Vector3(followTransform0.position.x, followTransform0.position.y, this.transform.position.z);
        }
        else if (player_flag == 1) {
            this.transform.position = new Vector3(followTransform1.position.x, followTransform1.position.y, this.transform.position.z);
        }
        

        //For one object, the camera permanently locks onto that object, cannot change behaviour
        //this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y+5, this.transform.position.z);        
    }
}