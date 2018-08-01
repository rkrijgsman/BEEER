using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Camera cam1;
    public Camera cam2;
    public Vector3 prevvelocity = new Vector3(0,0,1);
    public AudioSource pickupSound;

    private Vector3 steering, desired_velocity;
    private float maxSteering = 0.2f, maxVelocity = 5;
    private float angle, direction;
    [SerializeField]
    private float target;

    private Rigidbody rb;
    private int count;

    Vector3 originalPos;



    void Start()
    {
        pickupSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    
        cam1.enabled = true;
        cam2.enabled = false;

       
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        }


    void Update()
{
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cam1.enabled = !cam1.enabled;
            cam2.enabled = !cam2.enabled;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.transform.position = originalPos;
        }

       
    }


    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (cam2.enabled)
            rb.AddForce(movement * speed);
        else
        {
            target += moveHorizontal * 60 * Time.fixedDeltaTime;
            target = GetAngle(target);
            direction = Mathf.MoveTowardsAngle(direction, target, Time.fixedDeltaTime * 60);

            angle = Mathf.Deg2Rad * (-direction + 90);            
            desired_velocity = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle) ).normalized * maxVelocity;
            steering = desired_velocity - rb.velocity;

            if (moveVertical < 0)
                moveHorizontal = 0;
            float move = Mathf.Clamp( Mathf.Abs(moveHorizontal) + moveVertical, -1, 1);
            steering = Truncate(steering, maxSteering * move);
            rb.velocity = Truncate(rb.velocity + steering, maxVelocity);

            if( rb.velocity.magnitude > 0.1f)
                transform.forward = rb.velocity.normalized;
        }
    }

    public float GetAngle()
    {
        return direction;
    }

    private Vector3 Truncate(Vector3 vec, float maxLength) {
        if (vec.magnitude > maxLength)
            return vec.normalized * maxLength;

        return vec;
    }

    private float GetAngle(float angle)
    {
        angle = angle % 360;
        if (angle > 180)
            angle = -360 + angle;

        return angle;
    }

    void OnTriggerEnter(Collider other)

    {

       
        if (other.gameObject.CompareTag("Pick Up"))
        {
            pickupSound.Play();
            originalPos = gameObject.transform.position;
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            

        }


    }
    void SetCountText ()
    { countText.text = "Count: " + count.ToString();
    if (count >= 44)
        {
            winText.text = "You found and devoured all the rabbits! You win!";
        }
            }
}
