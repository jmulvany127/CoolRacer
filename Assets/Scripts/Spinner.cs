using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{

    public float rotateSpeed = 2.5f;

    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotateSpeed);
    }


}
