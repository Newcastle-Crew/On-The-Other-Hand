using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Health 
{

public class PlayerHealth : MonoBehaviour
{
    #region Health Variables

    public HealthBar healthBar; // Health bar UI.
    public HealItemController firstjab; // Healing mechanic - checks to see if the player's taken the syringe.
    public HealItemController secondjab;
    public HealItemController thirdjab;

    public int maxHealth = 480; // Maximum health - actual value set inside the inspector.
    public int currentHealth; // Current health. Used in this class to determine how much damage you've taken and keep the bar's UI accurate.
    private int DamageOverTime = 1; // Bleeding out mechanic.

    #endregion

    void Start() // Start is called before the first frame update
    {     
        currentHealth = maxHealth; // Starts the game and has the player at maximum health.
        healthBar.SetMaxHealth(maxHealth); // Starts the game with a full health bar.
        StartCoroutine(BleedOut()); // A coroutine that will make the player take 1 damage every second.
    }

    IEnumerator BleedOut()
    {
        float lastDecrementTime = 0f;
        float delayBetweenDecrements = 1f; // Keeps a 1-second gap between 'bleeds'.

        while (currentHealth > 0) // While the player's health is above 0...
      {
        if (Time.time - lastDecrementTime > delayBetweenDecrements) // And it's been a second since their last 'bleed'...
        {
            currentHealth -= 1; // Reduces the player's health by 1.
            healthBar.SetHealth(currentHealth); // Keeps the health bar's filling accurate
            lastDecrementTime += delayBetweenDecrements; // Keeps the time between each 'bleed' accurate.
        }
        yield return null;
      }
    }

    void TakeDamage (int damage)
    {
        currentHealth -= damage; // Reduces health number by the number of damage dealt.

        healthBar.SetHealth(currentHealth);
    }

    void Update() // Update is called once per frame
    {
        if (firstjab.Healing == true || secondjab.Healing == true || thirdjab.Healing == true) // Keeps an eye out for the player using a syringe.
        {
            currentHealth = maxHealth; // Sets the player's current health to maximum.
            healthBar.SetHealth(currentHealth); // Lets the health bar sprite know that the player's health is beefed up.
            firstjab.Healing = false; // Disables the healing after a second or so.
        }

        if (currentHealth <=0)
        {
            BacktoMenu();
        }

    }

    public static void BacktoMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1); // Loads the main menu screen when you die.
        Cursor.visible = true; // Makes the cursor visible.
        Cursor.lockState = CursorLockMode.None; // Allows the player to move their cursor around and click freely.
    }

}

}