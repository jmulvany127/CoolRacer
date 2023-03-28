using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowman : MonoBehaviour
{
    public float Range;                 // Range
    public Transform Target;
    public GameObject snowballPrefab;
    public Transform shootPoint;
    public float FireRate;
    public float Force;
    
    float nextTimeToFire = 0;
    bool Detected = false;
    Vector2 Direction;

    void Start()
    {

    }

    void Update()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);
        if (rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Racer")
            {
                if (Detected == false)
                {
                    Detected = true;
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                }
            }
        }

        if (Detected)
        {
            if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1/FireRate;
                throwSnowball();
            }
        }
    }

    void throwSnowball()
    {
        GameObject snowballIns = Instantiate(snowballPrefab, shootPoint.position, Quaternion.identity);
        snowballIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }
}