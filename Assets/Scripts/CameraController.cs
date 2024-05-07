using UnityEngine;

public class CameraController : MonoBehaviour
{

    Transform target; // allow us to set a target to follow
    Vector3 velocity = Vector3.zero; // this is used to smooth camera movement, initalized at 0
    [Range(0, 1)]
    public float smoothTime; // only able to choose 0 - 1, determines how smooth cameria movement is
    public Vector3 positionOffset; // offset applied to the position of the object relative to the target's position


    private void Awake()
    /* Starts before Start() */
    {

        target = GameObject.FindGameObjectWithTag("Player").transform; // setting the target to anything with a player tag

    }

    private void LateUpdate()
    /* Goes after Update() */
    {

        Vector3 targetPosition = target.position + positionOffset; // set the target position to the position of the target (yes i know the wording is crazy) + the offset determined



        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime); // Smoothly move the object's position towards the target position using Smooth Damp

        // The third parameter, ref velocity, is used to smooth the movement over time
        // smoothTime determines how quickly the object reaches the target position


    }

}
