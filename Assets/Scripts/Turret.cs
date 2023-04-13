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
    private float begin = 5;
    float nextTimeToFire = 0;               // Initializing next firing time
    Vector2 Direction;                      // Direction to shoot
    public ParticleSystem Explosion;        // Explosion when firing shell.

    void Update()
    {
        // Get position of target and calculate position in relation to Turret
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        // Check if target is within range
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);
        if (rayInfo)
        {
            // Faces Target
            Gun.transform.right = Direction;

            // Shoots at every given rate
            if(Time.time > nextTimeToFire && Time.timeSinceLevelLoad > begin)
            {
                nextTimeToFire = Time.time + 1/FireRate;
                Shoot();
            }
        }
    }

    // Instantiates projectile and shoots towards Target
    void Shoot()
    {
        GameObject projectileInstant = Instantiate(projectilePrefab, ShootingPoint.position, Gun.transform.rotation);
        ParticleSystem explosionInstant = Instantiate(Explosion, ShootingPoint.position, Quaternion.identity);
        projectileInstant.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }
}