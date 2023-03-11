using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikecollision : MonoBehaviour


{
    //enter this loop if collision happens
    private void OnCollisionEnter2D(Collision2D coll)
    {

        //check if collision happens with gameobject whos tag is Spike
        if (coll.gameObject.tag == "Spike")
        {
            //when collison happens destroy spike sprite
            Destroy(coll.gameObject);
            //write to log to indicate that a collision has happened
            Debug.Log("Hit Spike");



            //can add more code here
            //eg. when car hits spike move it by.....

        }

    }
}
