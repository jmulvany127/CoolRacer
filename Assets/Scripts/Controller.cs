using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    
    public FixedJoystick Joystick;
    Rigidbody2D racer;
    Vector2 move;
    Vector2 formermove;
    public Vector2 velocity;
    public float speed;
    //float formerangle;


    public float MaxSpinTime = 0.4f;
  
    
    private float formerangle = 0f;
    public bool isSpinning = false;
    public float spinTime = 0f;
  






    void Start()
    {
        racer = GetComponent<Rigidbody2D>();
        velocity.x = 0;
        velocity.y = 0;
    }

    void Update()
    {
        if (!isSpinning)
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
        else
        {
        
            // Spin the car 360 degrees
            transform.Rotate(0f, 0f, 360f * Time.deltaTime / MaxSpinTime);

            // Update spin time and check if spin time has elapsed
            spinTime += Time.deltaTime;
            if (spinTime > MaxSpinTime)
            {
                isSpinning = false;

            }
        }
    }


    void FixedUpdate(){
        

        float upacceleration = 0.20f;
        float downacceleration = 0.20f;

        // When the joystick is not used
        // the car will keep on moving but get slower
        if(move.x == 0 && move.y == 0){
            //racer.MovePosition(racer.position + formermove * speed * Time.fixedDeltaTime);
            if(speed > downacceleration){
                speed = speed - downacceleration;
            } else {
                speed = 0;
                velocity = new Vector2(0, 0);
            }

        } else {
        if(speed < 10){
            speed = speed + upacceleration;
        }
        }

        // When the joystick is used
        // the car will move to the desired direction and get faster        
        float reduce = 0.1f;
        float max_velocity = 4f;
        float velocity_control_factor = 0.95f;
        velocity = velocity + reduce * move * speed * Time.fixedDeltaTime;
        if (velocity.x > max_velocity) {
            velocity.x = max_velocity;
        }
        if (velocity.y > max_velocity) {
            velocity.y = max_velocity;
        }

        velocity = velocity * velocity_control_factor;

        racer.MovePosition(racer.position + velocity);
        formermove = move;

        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        
        if(collision.gameObject.tag == "Bouncer")
        {
            float bounce = 2f;
            velocity *= -bounce;
        }

        if(collision.gameObject.tag == "Spinner")
        {
            float bounce = 2f;
            velocity *= -bounce;
    
            isSpinning = true;
            spinTime = 0f;

        }
    }





    public void ResetPosition() {
        Vector2 zero = new Vector2(0,0);
        velocity = zero;
        var angle = Mathf.Atan2(1,0)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
