using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public Movement2D movement;
    private Animator anim;     //reference to animator comp
    private float damageTime = 1f;

    // References to UI elements
    public Text healthText;               // Text displaying the player's health
    public int maxHealth = 100;           // Maximum health the player can have
    public int currentHealth = 100;       // Current health the player has
    private float healTimer = 0f;         // Timer to track healing intervals
    private float healInterval = 15f;      // Time interval for healing in seconds
    private int healAmount = 2;           // Amount to heal each interval

    private bool isGamePaused = false;    // Flag to check is game is paused

    public GameOverScript gameOverScript;   //has accsees to this script

    void Start()
    {
        UpdateUI();              // Initialize the UI with the current health
    }

    void Update()
    {
        if (!isGamePaused) //check if game is not already paused
        {
            if (currentHealth > 0) //if the player has more than 0 hp, it can then use the heal system
            {
                // Check the timer and heal the player if the interval has passed
                healTimer += Time.deltaTime;
                if (healTimer >= healInterval)
                {
                    Heal(healAmount);
                    healTimer = 0f; // Reset the timer
                }
            }
        }
    }

    void UpdateUI()
    {
        healthText.text = "Health: " + currentHealth + " / " + maxHealth;   // Update the health text on the UI
    }

    // Function to deduct health when the player takes damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;                       // Reduce current health by the damage amount
        currentHealth = Mathf.Max(currentHealth, 0);   // Ensure health doesn't go below 0
        UpdateUI();                                    // Update the UI to reflect the new health
        movement.isHurt = true;

        if (currentHealth <= 0 && !isGamePaused)
        {
            PauseGame(); // Call the pause method when the health reached 0
        }
        else
        {
            StartCoroutine("IEHurt");
        }
    }

    // Function to increase the player's health
    public void Heal(int healingAmount)
    {
        currentHealth += healingAmount;                         // Increase current health by the healing amount
        currentHealth = Mathf.Min(currentHealth, maxHealth);    // Ensure health doesn't exceed the maximum
        UpdateUI();                                             // Update the UI to reflect the new health
    }

    // Handle collisions with trap objects
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap"))
        {
            TakeDamage(15);      // Adjust the damage amount as needed when colliding with a "Trap"
        }
    }

    public IEnumerator IEHurt()
    {
        yield return new WaitForSeconds(damageTime);
        movement.isHurt = false;
    }

    //Method to pause the game
    void PauseGame()
    {
        Time.timeScale = 0;   //forces the game scale to be 0 effectively pausing it

        isGamePaused = true;    //stating that the game is now paused

        if (gameOverScript != null)
        {
          gameOverScript.ShowGameOverScript(); //calling gameoverscript method to be played
        }
        else
        {
            Debug.LogWarning("No gameoverscript");
        }
       
    }
}
