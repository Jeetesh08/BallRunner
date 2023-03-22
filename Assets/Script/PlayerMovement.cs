
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sideWaysForce = 500f;

    private bool moveLeft; // Whether the player should move left
    private bool moveRight;

    public AudioSource audio;
    public static PlayerMovement instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(forwardForce < 75)
        {
            forwardForce = 15 + (this.transform.position.z /60);
        }
        // rb.velocity = new Vector3(0f, 0f,15f);

        // Adding forward Force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
        

        if (Input.GetKey("d")||Input.GetKey("right"))
        {
            rb.AddForce(sideWaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a")||Input.GetKey("left"))
        {
            rb.AddForce(-sideWaysForce  * Time.deltaTime, 0, 0 , ForceMode.VelocityChange);
        }

        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        // Check for touch input on the left or right half of the screen
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x < Screen.width / 2)
                {
                    moveLeft = true;
                }
                else
                {
                    moveRight = true;
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                moveLeft = false;
                moveRight = false;
            }
        }

       

        // Move the player left or right based on touch input
        if (moveLeft)
        {
            rb.AddForce(-sideWaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else if (moveRight)
        {
            rb.AddForce(sideWaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }

    public void Right()
    {
        rb.AddForce(sideWaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }public void Left()
    {
        rb.AddForce(-sideWaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}
