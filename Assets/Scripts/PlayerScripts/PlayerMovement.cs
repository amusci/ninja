using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8f; // speed of player
    public float jumpingPower = 5f; // jump height of player
    private float horizontal; // we use this variable for left and right keyboard inputs
    private bool isFacingRight = true; // boolean to dicate if player is right or left (start right)
    /* Coyote Jump Variables 
    
        These allow us to jump just after leaving a platform to include player fault

    */
    [SerializeField] private float coyoteTime = 0.2f; // .2 seconds before falling off platform

    private float coyoteTimeCounter; // Variable to keep track of the count


    /* Jump Buffer Variables 

    These allow us to jump before touching the ground for a more smooth experience
    
    */
    [SerializeField] private float jumpBufferTime = 0.05f; // the time you can jump before actually touching the ground
    private float jumpBufferCounter; // counter variable

    [SerializeField] private Rigidbody2D rb; // allow the script to interact with a rigid body
    [SerializeField] private Transform groundCheck; // allow the script to interact with a ground check
    [SerializeField] private LayerMask groundLayer; // allow the script to interact with a ground layer

    // DEBUG VARIABLES ONLY

    public Text yVelocityText; // Reference to the UI Text element
    public Text xVelocityText; // Reference to the UI Text element


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

        if (Input.GetButtonDown("Jump"))
        {

            jumpBufferCounter = jumpBufferTime; // jump buffer counter set to the jump buffer time
        }
        else
        {

            jumpBufferCounter -= Time.deltaTime; //  decrement time from the current count

        }

        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0) // make sure jump buffer counter > 0 and coyote time counter > 0
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpingPower); // set y velocity to jumpingPower

            jumpBufferCounter = 0f; // reset jump buffer counter

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

            Vector3 rotation = transform.localRotation.eulerAngles; // get the rotation of the object 

            rotation.y += 180f; // add 180 to the y which would flip

            transform.localRotation = Quaternion.Euler(rotation); // apply 

        }

    }
}
