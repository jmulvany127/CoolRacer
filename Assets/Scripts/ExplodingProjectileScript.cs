using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingProjectileScript : MonoBehaviour
{
    public ParticleSystem Explosion;        // Variable Particle System to handle explosion

    // If collision, create explosion effect and then destroys itself
    void OnCollisionEnter2D(Collision2D Col)
    {
        if (FlowManager.Instance.Track == 3) {
            if (Col.gameObject.tag == "bound" || Col.gameObject.tag == "Racer") {
                ParticleSystem explosionInstant = Instantiate( Explosion, this.transform.position, Quaternion.identity );
                Destroy(this.gameObject);
            } else {
                Physics2D.IgnoreCollision(Col.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
        } else {
            ParticleSystem explosionInstant = Instantiate( Explosion, this.transform.position, Quaternion.identity );
            Destroy(this.gameObject);
        }

    }
}
