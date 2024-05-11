using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed; // control enemy speed
    public Transform[] patrolPoints; // array of patrol points
    public int patrolDestination; // control which point we want to move to

    private Transform player; // referencing the player's transform

    public float detectionRange = .2f; // range of detection

    private bool followingPlayer; // false when not following, true when following

    /* testing ground check */
    [SerializeField] private Transform groundCheck; // allow the script to interact with a ground check
    [SerializeField] private LayerMask groundLayer; // allow the script to interact with a ground layer



    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    /* Called once per frame */
    {

        if (!followingPlayer) // if the enemy hasnt found a player 
        {

            Patrol(); // patrol
            checkForPlayer(); // check for player while patroling

        }
        else // player detected
        {

            FollowPlayer(); //follow player 

        }


    }



    void FollowPlayer()
    {
        bool grounded = isGrounded(); // check if the player is grounded

        if (!grounded) // if the enemy is not grounded
        {

            disableCollisions(); // this is the worst workaround i have ever created and i will not be fixing this for awhile.
            Debug.LogWarning("not grounded");


        }
        else // if the enemy is grounded
        {

            reEnableCollisions(); // im sorry God

            Vector2 targetPosition = new Vector2(player.position.x, transform.position.y); // move towards the player only in the x-axis
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, (moveSpeed + 2) * Time.deltaTime); // move towards the player
        }
    }


    private bool isGrounded()

    /* determine if the player's groundcheck overlaps with anything with a ground layer */
    {


        // Use Physics2D.OverlapCircle to check if there's any collider overlapping with the groundCheck position
        // The 0.2f radius defines how far the ground check extends
        // The groundLayer is the layer mask used to filter what objects should be considered as ground

        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }

    void checkForPlayer()
    /* Check to see if player is in the detection range of enemy */
    {

        if (Vector2.Distance(transform.position, player.position) <= detectionRange) // if player in detection range
        {

            followingPlayer = !followingPlayer; // flip bool


        }

    }


    void Patrol()
    /* function that handles enemy patrol */
    {

        if (patrolDestination == 0) // if we want to go to the 0 point (regardless of where we are)
        {

            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime); // move towards the point

            if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f) // if we are .2f close to the point we want to reach
            {

                transform.localScale = new Vector3(3, 3, 3); // making sure the sprite is facing where it was drawn
                patrolDestination = 1; // next point

            }
        }
        if (patrolDestination == 1) // if we want to go to the 1 point (regardless of where we are)
        {

            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            //move towards the point

            if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f) // if we are .2f close
            {

                transform.localScale = new Vector3(-3, 3, 3); // flip the sprite
                patrolDestination = 0; // set to next point

            }

        }

    }

    void disableCollisions()
    {

        // disable collisions with other colliders
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 100f); // get an array of colliders within 100f
        foreach (Collider2D collider in colliders) // iterate through each collider
        {
            if (collider != GetComponent<Collider2D>()) // check if collider is not enemy's
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider, true);  // disable collider between enemy and collider
            }
        }

    }

    void reEnableCollisions()
    {

        // Re-enable collisions with all other colliders
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 100f); // get an array of colliders within 100f
        foreach (Collider2D collider in colliders) // iterate through each collider
        {
            if (collider != GetComponent<Collider2D>()) // check if collider is not enemy's
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider, false); // disable collider between enemy and collider
            }
        }

    }

}