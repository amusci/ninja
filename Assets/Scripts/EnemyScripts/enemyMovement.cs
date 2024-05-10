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

    public Text followingPlayerText; // Reference to the UI Text element

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
    /* Moves enemy to the player */
    {

        transform.position = Vector2.MoveTowards(transform.position, player.position, (moveSpeed + 2) * Time.deltaTime); // move towards player 

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
}