using UnityEngine;

public class MonsterDamage : MonoBehaviour
{

    public int damage; // amount of damage the enemy will do
    public PlayerHealth playerHealth; // accessing player health from PlayerHealth.cs

    private void OnCollisionEnter2D(Collision2D collision)
    /* When enemy collides with player, do damage to player */
    {
        if (collision.gameObject.tag == "Player") // if collide with gameobject "player"
        {

            playerHealth.TakeDamage(damage); // decrement the amount of health 

        }

    }

}
