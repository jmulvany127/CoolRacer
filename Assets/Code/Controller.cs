using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    
    public FixedJoystick Joystick;
    Rigidbody2D racer;
    Vector2 move;
    Vector2 formermove;
    public float speed;

    float formerangle;

    void Start()
    {
        racer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move.x = Joystick.Horizontal;
        move.y = Joystick.Vertical;

        float xAxis = move.x;
        float yAxis = move.y;
        float zAxis = Mathf.Atan2(xAxis,yAxis)*Mathf.Rad2Deg;
        
        
        if(zAxis != 0){
            transform.eulerAngles = new Vector3(0f,0f,-zAxis);
            formerangle = zAxis;
        }else{
            transform.eulerAngles = new Vector3(0f,0f,-formerangle);
        }
        

    }

    void FixedUpdate(){
        

        float upacceleration = 0.05f;
        float downacceleration = 0.05f;

        // When the joystick is not used
        // the car will keep on moving but get slower
        if(move.x == 0 && move.y == 0){
            racer.MovePosition(racer.position + formermove * speed * Time.fixedDeltaTime);
            if(speed > 0){
                speed = speed - downacceleration;
            }
            
        }
        
        
        // When the joystick is used
        // the car will move to the desired direction and get faster
        else{
            racer.MovePosition(racer.position + move * speed * Time.fixedDeltaTime);
            formermove = move;
            speed = speed + upacceleration;
        }
        
    }
}
