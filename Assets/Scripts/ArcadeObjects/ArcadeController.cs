using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeController : MonoBehaviour
{
    
    public FixedJoystick Joystick;
    Rigidbody2D racer;
    Vector2 move;
    Vector2 formermove;
    public float speed;

    float formerangle;
    float posY;

    void Start()
    {
        racer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        move.x = 0;
        move.y = Joystick.Vertical;

        // float xAxis = 0;
        // float yAxis = move.y;
        // float zAxis = Mathf.Atan2(xAxis,yAxis)*Mathf.Rad2Deg;
        
        
        // if(zAxis != 0){
        //     transform.eulerAngles = new Vector3(0f,0f,-zAxis);
        //     formerangle = zAxis;
        // }else{
        //     transform.eulerAngles = new Vector3(0f,0f,-formerangle);
        // }

        posY = racer.position.y;

        if (posY > 4.5) {
            transform.position = new Vector3(racer.position.x, 4.5f, 50);
        }
        else if (posY < -4.5) {
            transform.position = new Vector3(racer.position.x, -4.5f, 50);
        }


    }

    void FixedUpdate(){
        

        float upacceleration = 0.045f;
        float downacceleration = 0.08f;

        // When the joystick is not used
        // the car will keep on moving but get slower
        if(move.x == 0 && move.y == 0){
            racer.MovePosition(racer.position + formermove * speed * Time.fixedDeltaTime);
            if(speed > 0){
                speed = speed - downacceleration;
            }

            if (speed < 0) {
                speed = 0;
            }
            
        }
        
        
        // When the joystick is used
        // the car will move to the desired direction and get faster
        else{
            racer.MovePosition(racer.position + move * speed * Time.fixedDeltaTime);
            formermove = move;
            speed = speed + upacceleration;

            //Car has speed limit of 15
            //**Suggestion: add a max speed, results in the speed decreasing instantly by 10 or so, adds effect of engine overheating or something, idk
            if (speed > 12) {
                speed = 12;
            }
        }
        
    }
}
