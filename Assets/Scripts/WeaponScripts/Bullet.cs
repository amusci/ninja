using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed; // bullet speed
    public int damage; // bullet damage
    private Rigidbody2D rb; // rigid body reference


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // get rb reference


    }
    void Update()
    {

        rb.velocity = transform.right * speed; // take the right transform and * speed of the bullet

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>(); // get the enemy health 

            if (enemy != null) // if enemy exists
            {

                enemy.takeDamage(damage); // take damage
                Destroy(gameObject); // DESTROY THE GAME OBJECT!!!!!


            }


        }
    }


}
