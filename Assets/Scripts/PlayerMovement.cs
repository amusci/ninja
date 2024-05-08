using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f; // speed of player
    public float jumpingPower = 5f; // jump height of player
    private float horizontal; // we use this variable for left and right keyboard inputs
    private bool isFacingRight = true; // boolean to dicate if player is right or left (start right)
    [SerializeField] private float coyoteTime = 0.2f; // .2 seconds before falling off platform
    private float coyoteTimeCounter; // Variable to keep track of the count
    [SerializeField] private Rigidbody2D rb; // allow the script to interact with a rigid body
    [SerializeField] private Transform groundCheck; // allow the script to interact with a ground check
    [SerializeField] private LayerMask groundLayer; // allow the script to interact with a ground layer

    // DEBUG VARIABLES ONLY

    public Text yVelocityText; // Reference to the UI Text element
    public Text xVelocityText; // Reference to the UI Text element



    void Start()

    /* Start is called before the first frame update */
    {




    }


    void Update()

    /* Update is called once per frame */
    {

        horizontal = Input.GetAxisRaw("Horizontal"); // getting left and right inputs
        yVelocityText.text = "Velocity Y: " + rb.velocity.y.ToString(); // y velocity debugging
        xVelocityText.text = "Velocity X: " + rb.position.x.ToString(); // x velocity debugging

        if (isGrounded())
        {

            coyoteTimeCounter = coyoteTime; // if grounded, reset the counter

        }
        else
        {

            coyoteTimeCounter -= Time.deltaTime; // decrement time from the current count

        }

        if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0) // make sure jump button pressed and to make sure the player is grounded
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpingPower); // set y velocity to jumpingPower

        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) // if jump button is let go while mid jump
        {

            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); // reduce y velocity 
            coyoteTimeCounter = 0f; // to make sure we cant double jump, set the count to 0 when button is let go
        }


        Flip(); // see line 61

    }

    private void FixedUpdate()

    /* Called once per physics frame */
    {

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); // left and right movement



    }

    private bool isGrounded()

    /* determine if the player's groundcheck overlaps with anything with a ground layer */
    {


        // Use Physics2D.OverlapCircle to check if there's any collider overlapping with the groundCheck position
        // The 0.2f radius defines how far the ground check extends
        // The groundLayer is the layer mask used to filter what objects should be considered as ground

        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }
    private void Flip()

    /* flip player based on direction */
    {

        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) // Check if the player is facing right and moving left, or facing left and moving right
        {

            isFacingRight = !isFacingRight; // reverse the facing directions

            Vector3 localScale = transform.localScale; // get the scale of the object 

            localScale.x *= -1f; // flip the scale

            transform.localScale = localScale; // apply the flip back to the object

        }

    }
}
