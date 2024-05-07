using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal; // we use this variable for left and right keyboard inputs
    public float speed = 8f; // speed of player
    public float jumpingPower = 5f; // jump height of player
    private bool isFacingRight = true; // boolean to dicate if player is right or left (start right)
    [SerializeField] private Rigidbody2D rb; // allow the script to interact with a rigid body
    [SerializeField] private Transform groundCheck; // allow the script to interact with a ground check
    [SerializeField] private LayerMask groundLayer; // allow the script to interact with a ground layer



    void Start()

    /* Start is called before the first frame update */
    {



    }


    void Update()

    /* Update is called once per frame */
    {

        horizontal = Input.GetAxisRaw("Horizontal"); // getting left and right inputs

        if (Input.GetButtonDown("Jump") && isGrounded()) // make sure jump button pressed and to make sure the player is grounded
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpingPower); // set y velocity to jumpingPower

        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) // if jump button is let go while mid jump
        {

            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f); // reduce y velocity 
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