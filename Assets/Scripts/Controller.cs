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

    public ParticleSystem Fire;
    public float MaxSpinTime = 0.4f;
  
    private float formerangle = 0f;
    public bool isSpinning = false;
    public float spinTime = 0f;

    public bool stopBurning = true;
    public bool keepBurning = false;
    private float burnTime = 0f;
    private float maxBurnTime = 1f;
    [SerializeField] public Sprite [] CarSprites; // To hold different car sprites






    void Start()
    {
        racer = GetComponent<Rigidbody2D>();
        velocity.x = 0;
        velocity.y = 0;
    }

    void Update()
    {
        //if the race car is not being affected by a colliosn with a spinner movement and rotation is controlled by joystick
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
        //if spinner rotation has occured then spin teh ca 360 degrees over a period of max spin time
        else
        {
        
            // Spin the car 360 degrees
            transform.Rotate(0f, 0f, 360f * Time.deltaTime / MaxSpinTime);

            // Update spin time 
            spinTime += Time.deltaTime;
            // check if spin time has elapsed, if so set isSpinnin to false to return controll to user
            if (spinTime > MaxSpinTime)
            {
                isSpinning = false;

            }
        }

        // Continue lava burning effect for 1s after collision exit
        if (keepBurning) {
            ParticleSystem FireInstant = Instantiate(Fire, this.transform.position, Quaternion.identity);

            velocity *= 0.95f; // Matches the velocity during collision best
	        if(stopBurning) {
                burnTime += Time.deltaTime;
                if (burnTime > maxBurnTime) {
                    keepBurning = false;
                    //GetComponent<SpriteRenderer>().sprite =  CarSprites[0];
                    burnTime = 0;
                }
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

        //if spinner collsion has occurred then bounce the vehicle and spin it 360 degrees 
        
        if(collision.gameObject.tag == "Spinner")
        {
            float bounce = 2f;
            velocity *= -bounce;
    
            isSpinning = true;
            spinTime = 0f;

        }

        if(collision.gameObject.tag == "Snowball")
        {
            speed = 0;      // If collision with SnowBall, slow down to 0
        }

        if(collision.gameObject.tag == "Explode")
        {
            keepBurning = true;
            // Creates a force based on projectile (Might Need Improvement)
            Vector2 explodeDirection = racer.transform.position - collision.gameObject.transform.position;
            racer.GetComponent<Rigidbody2D>().AddForce(explodeDirection * 4000f);
            velocity *= 2f;
            speed = 0;
        }
        
        if (collision.gameObject.tag == "Snowman") {
            velocity *= -2f;
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = collision.gameObject.GetComponent<TwoHits>().hit;
            Destroy(collision.gameObject.GetComponent<Collider2D>());
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Explode")
        {
            keepBurning = true;
            // Creates a force based on projectile (Might Need Improvement)
            Vector2 explodeDirection = racer.transform.position - other.gameObject.transform.position;
            racer.GetComponent<Rigidbody2D>().AddForce(explodeDirection * 4000f);
            velocity *= 2f;
            speed = 0;
        }
    }



    public void ResetPosition() {
        Vector2 zero = new Vector2(0,0);
        velocity = zero;
        var angle = Mathf.Atan2(1,0)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
