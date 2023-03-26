using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSpawner : MonoBehaviour
{
    public GameObject Traffic;
    public float spawnRate = 5;
    private float timer = 0;
    private int lane = 0; 
    public float y, init_speed, speedOffset;
    public float floor_range, top_range, diffOffset;
    // Start is called before the first frame update
    void Start()
    {
     diffOffset = 0.03f;
     floor_range = 0.25f;
     top_range = 3.5f; 
     init_speed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //3 random vars, spawn rate, velocity and position
        if(timer < spawnRate){
            timer += Time.deltaTime;
        }
        else{
            // get new random vars
            init_speed += speedOffset;
            if(top_range > 0.7f){
                top_range -= diffOffset;
            }
            spawnRate = Random.Range(floor_range, top_range);
            lane = Random.Range(0, 4);
            y = -4.5f + 3 * lane;

            Instantiate(Traffic, new Vector3(18, y, 30), transform.rotation);
            timer = 0;
        }

    }
}
