using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float Range;                 // Range
    public Transform Target;
    public GameObject projectilePrefab;
    public GameObject gun;
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
            gun.transform.up = Direction;
            if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1/FireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        GameObject projectileInstant = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        projectileInstant.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }
}