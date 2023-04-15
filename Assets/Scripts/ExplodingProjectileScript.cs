using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingProjectileScript : MonoBehaviour
{
    public ParticleSystem Explosion;        // Variable Particle System to handle explosion

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Racer"){
            ParticleSystem explosionInstant = Instantiate(Explosion, this.transform.position, Quaternion.identity );
            Destroy(this.gameObject);
        }
    }

    // If collision, create explosion effect and then destroys itself
    void OnCollisionEnter2D(Collision2D Col)
    {
        if (FlowManager.Instance.Track != 3) {
            ParticleSystem explosionInstant = Instantiate( Explosion, this.transform.position, Quaternion.identity );
            Destroy(this.gameObject);
        }

    }
}
