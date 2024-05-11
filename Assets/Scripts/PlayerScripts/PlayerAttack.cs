using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform shootingPoint;
    public GameObject bulletPrefab;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);

        }

    }
}
