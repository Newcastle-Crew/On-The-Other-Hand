using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    #region Dialogue Variables
    [SerializeField] private DialogueUI dialogueUI; // Will be used to only show UI when the player is close to a speaker.

    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }
    #endregion
    
    #region Health Variables

    public int maxHealth = 600;
    public int currentHealth;
    private int DamageOverTime = 1;
    public HealthBar healthBar;

    #endregion
    
    private void Start() /// Start is called before the first frame update
    {        
        currentHealth = maxHealth; // Starts the game and has the player at maximum health.
        healthBar.SetMaxHealth(maxHealth);
        StartCoroutine(BleedOut());
    }

    private void Update()
    {   
        if (dialogueUI.IsOpen) return; // Stops the player from spamming extra dialogue boxes while the dialogue box is appearing.

        if (Input.GetKeyDown(KeyCode.E)) // If the player presses E and the object can be interacted with, interact with it.
        {
            Interactable?.Interact(player:this);
        }
    }

    IEnumerator BleedOut()
    {
        float lastDecrementTime = 0f;
        float delayBetweenDecrements = 1f;

        while (currentHealth > 0)
  {
        if (Time.time - lastDecrementTime > delayBetweenDecrements)
        {
            currentHealth -= 1;
            healthBar.SetHealth(currentHealth);
            lastDecrementTime += delayBetweenDecrements;
        }
        yield return null;
        }
    }

    void TakeDamage (int damage)
    {
        currentHealth -= damage; // Reduces health number by the number of damage dealt.

        healthBar.SetHealth(currentHealth);
    }
}