using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform[] patrolPoints; // array of patrol points
    public float moveSpeed; // control enemy speed
    public int patrolDestination; // control which point we want to move to

    void Update()
    /* Called once per frame */
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

