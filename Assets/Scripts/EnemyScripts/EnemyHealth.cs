
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 10; // setting max health of enemy
    public int health; // health variable 

    public void takeDamage(int damage)
    /* allows enemy to take damage */
    {

        health -= damage; // decrement health
        if (health <= 0) // if health is negative
        {

            Destroy(gameObject); // DESTROY GAME OBJECT

        }

    }
}
