using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 10; // setting max health of player
    public int health; // health variable 


    public Text healthText; // Reference to the UI Text element

    void Update()
    {
        healthText.text = "Health: " + health.ToString(); // health debug
    }
    void Start()
    {
        health = maxHealth; // setting max health to be used
    }

    public void TakeDamage(int damage)
    {
        /* function to allow the player to take damage */



        health -= damage; // see MonsterDamage.cs line 9
        if (health <= 0) // if health is 0/negative kill player
        {

            Destroy(gameObject);

        }

    }
}
