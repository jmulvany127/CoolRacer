using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSpawner : MonoBehaviour
{
    // Declare game objects
    public Traffic MyTraffic;
    public Coin MyCoin;
    public Truck MyTruck;
    public Cones MyCones;
    public VTruck MyVTruck;
    public Diamond MyDiamond;

    // Declare & Initialise variables
    public float spawnRate = 5;
    public float timer = 0;
    public int lane = 0; 
    public int total_odd, traffic_odd, next_type = 0;
    private int reward_type;
    public int coin_odd, truck_odd, Vtruck_odd;
    public int truck_spawnTime, cones_spawnTime, V_spawnTime;
    public float y;
    public float floor_range, top_range, diffOffset;
    // Start is called before the first frame update
    void Start()
    {
        // Set a rand var so that for say, 9/10 times, traffic will spawn. The other time a coin object will spawn.
        total_odd = 25;
        Vtruck_odd = 5;
        traffic_odd = 11;
        coin_odd = 13;
        truck_odd = 17;
        // Spawn times
        truck_spawnTime = 30;
        cones_spawnTime = 60;
        V_spawnTime = 55;
        // Set offset vars
        diffOffset = 0.03f;
        floor_range = 0.5f;
        top_range = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // Execute an action after a time delay: spawnRate
        if(timer < spawnRate){
            timer += Time.deltaTime;
        }
        else{
            // get new random vars
            if(top_range > 0.6f){
                top_range -= diffOffset;
            }
            if(floor_range > 0.3f){
                floor_range -= diffOffset;
            }
            // Set next spawn time delay
            spawnRate = Random.Range(floor_range, top_range);
            // Set lane for object to spawn into
            lane = Random.Range(0, 4);
            y = -4.5f + 3 * lane;
            // Choose which type of object to spawn next randomly
            next_type = Random.Range(0, total_odd);
            // Instantiate chosen object based on logic below...
            /*
                If the rand number is within the range for Traffic Spawn or the range for Coin spawn, they will spawn unconditionally
                Whereas, with Truck & Cones:
                To give a sense of increased difficulty, these two objects, which are harder to navigate, due to there increased hitbox size, 
                Will only spawn after a set duration of time, otherwise the default traffic object will spawn in its place.
            */
            if(next_type <= Vtruck_odd && Time.realtimeSinceStartup > V_spawnTime){
                VTruck NewVTruck = Instantiate(MyVTruck, new Vector3(12, 10, 30), transform.rotation);
            }


            if(next_type <= traffic_odd){
                Traffic newTraffic = Instantiate(MyTraffic, new Vector3(18, y, 30), transform.rotation);
            }
            else if(next_type <= coin_odd){
                // Spawn a reward item: 1/10 chance of a diamond
                reward_type = Random.Range(0,10);
                if(reward_type < 8){
                    Coin newCoin = Instantiate(MyCoin, new Vector3(18, y, 30), transform.rotation);
                } else {
                    Diamond newDiamond = Instantiate(MyDiamond, new Vector3(18, y, 30), transform.rotation);
                }
            }
            else{
                if(next_type <= truck_odd && Time.realtimeSinceStartup > truck_spawnTime){
                    Truck newTruck = Instantiate(MyTruck, new Vector3(18, y, 30), transform.rotation);
                }
                else if(Time.realtimeSinceStartup > cones_spawnTime){
                    //Special case for Cones: since this object is two lanes wide, we need a bit of extra handling...
                    y = -3 + 3 * (2 * (lane % 2));
                    Cones NewCones = Instantiate(MyCones, new Vector3(18, y, 30), transform.rotation);
                }
                else {
                    Traffic newTraffic = Instantiate(MyTraffic, new Vector3(18, y, 30), transform.rotation);
                }
            }
            timer = 0;
        }

    }
}
