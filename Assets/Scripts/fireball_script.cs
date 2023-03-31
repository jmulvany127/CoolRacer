using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball_script : MonoBehaviour
{
    public ParticleSystem Explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D Col)
    {
        ParticleSystem explosionInstant = Instantiate( Explosion, this.transform.position, Quaternion.identity );
        Destroy(this.gameObject);
    }
}
