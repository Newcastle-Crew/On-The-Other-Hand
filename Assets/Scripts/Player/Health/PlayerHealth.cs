# region Using
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#endregion

namespace Health 
{

public class PlayerHealth : MonoBehaviour
{
    #region Health Variables

    public HealthBar healthBar; // Health bar UI.
    public HealItemController firstjab; // Healing mechanic - checks to see if the player's taken the syringe.
    public HealItemController secondjab;
    public HealItemController thirdjab;
    public HealItemController fourthjab;
    public HealItemController fifthjab;

    public int maxHealth = 480; // Maximum health - actual value set inside the inspector.
    public int currentHealth; // Current health. Used in this class to determine how much damage you've taken and keep the bar's UI accurate.
    private int DamageOverTime = 1; // Bleeding out mechanic.

    #endregion

    void Start() // Start is called before the first frame update
    {     
        currentHealth = maxHealth; // Starts the game and has the player at maximum health.
        healthBar.SetMaxHealth(maxHealth); // Starts the game with a full health bar.
        Debug.Log($"{maxHealth}, {currentHealth}");
        StartCoroutine(BleedOut()); // A coroutine that will make the player take 1 damage every second.
    }

    public void WrongBox()
    {
        currentHealth -= 150; // When the player opens the wrong box, take off a chunk of their blood.
    }

    IEnumerator BleedOut()
    {
        float delayBetweenDecrements = 1f; // Keeps a 1-second gap between 'bleeds'.

        while (currentHealth > 0) // While the player's health is above 0...
        {
            yield return new WaitForSeconds(delayBetweenDecrements); //This delays the apporopriate amount of time AND pauses when the game pauses
            currentHealth -= 1; // Reduces the player's health by 1.
            healthBar.SetHealth(currentHealth); // Keeps the health bar's filling accurate
        }
    }

    void TakeDamage (int damage)
    {
        currentHealth -= damage; // Reduces health number by the number of damage dealt.

        healthBar.SetHealth(currentHealth);
    }

    void Update() // Update is called once per frame
    {
        if (firstjab.Healing == true || secondjab.Healing == true || thirdjab.Healing == true || fourthjab.Healing == true || fifthjab.Healing == true) // Keeps an eye out for the player using a syringe.
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
        Debug.Log("reload scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1); // Loads the main menu screen when you die.
        Cursor.visible = true; // Makes the cursor visible.
        Cursor.lockState = CursorLockMode.None; // Allows the player to move their cursor around and click freely.
    }
}

}