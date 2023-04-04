using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Public Variables
    public float Range;                     // Range of Turret
    public Transform Target;                // Target of Turret
    public GameObject projectilePrefab;     // Projectile of Turret
    public GameObject Gun;                  // Turret's Gun that moves
    public Transform ShootingPoint;            // Region where bullet comes from
    public float FireRate;                  // Rate of fire of Turret
    public float Force;                     // Force of the bullet
    
    float nextTimeToFire = 0;               // Initializing next firing time
    bool Detected = false;                  // Detection bool
    Vector2 Direction;                      // Direction to shoot

    void Update()
    {
        // Get position of target and calculate position in relation to Turret
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;

        // Check if target is within range
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
            // Faces Target
            Gun.transform.up = Direction;

            // Shoots at every given rate
            if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1/FireRate;
                Shoot();
            }
        }
    }

    // Instantiates projectile and shoots towards Target
    void Shoot()
    {
        GameObject projectileInstant = Instantiate(projectilePrefab, ShootingPoint.position, Quaternion.identity);
        projectileInstant.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }
}