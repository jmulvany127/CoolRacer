using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingProjectileScript : MonoBehaviour
{
    public ParticleSystem Explosion;        // Variable Particle System to handle explosion

    // If collision, create explosion effect and then destroys itself
    void OnCollisionEnter2D(Collision2D Col)
    {
        ParticleSystem explosionInstant = Instantiate( Explosion, this.transform.position, Quaternion.identity );
        Destroy(this.gameObject);
    }
}
