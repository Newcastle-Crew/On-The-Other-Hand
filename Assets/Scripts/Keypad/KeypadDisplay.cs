#region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class KeypadDisplay : MonoBehaviour
{
    [SerializeField] private Sprite[] digits;
    [SerializeField] private Image[] characters;

    private string codeSequence;

    public AudioSource beeping; // beeps for correct code
    public bool correctEntered = false; // checks for correct code

    void Start() // Start is called before the first frame update
    {
        codeSequence = "";

        for (int i = 0; i <= characters.Length -1; i++)
        {
            characters[i].sprite = digits[10];
        }

        KeypadButtons.ButtonPressed += AddDigitToCodeSequence;
    }

    private void Update()
    {
        if(correctEntered)
        {
            beeping.Play();
        }
    }

    private void AddDigitToCodeSequence(string digitEntered)
    {
        if(codeSequence.Length < 4)
        {
            switch (digitEntered)
            {
                case "Zero": // Pressing the Zero button will add a 0 to the sequence.
                codeSequence +="0";
                DisplayCodeSequence(0);
                break;

                case "One": // Adds 1 to the sequence.
                codeSequence +="1";
                DisplayCodeSequence(1);
                break;

                case "Two": // Adds 2 to the sequence.
                codeSequence +="2";
                DisplayCodeSequence(2);
                break;

                case "Three": // Adds 3 to the sequence.
                codeSequence +="3";
                DisplayCodeSequence(3);
                break;

                case "Four": // Adds 4 to the sequence.
                codeSequence +="4";
                DisplayCodeSequence(4);
                break;

                case "Five": // Adds 5 to the sequence.
                codeSequence +="5";
                DisplayCodeSequence(5);
                break;

                case "Six": // Adds 6 to the sequence.
                codeSequence +="6";
                DisplayCodeSequence(6);
                break;

                case "Seven": // Adds 7 to the sequence.
                codeSequence +="7";
                DisplayCodeSequence(7);
                break;

                case "Eight": // Adds 8 to the sequence.
                codeSequence +="8";
                DisplayCodeSequence(8);
                break;

                case "Nine": // Adds 9 to the sequence.
                codeSequence +="9";
                DisplayCodeSequence(9);
                break;
            }
        }

        switch (digitEntered)
        {
            case "Clear":
            ResetDisplay(); // When the player presses the clear button, it will reset the numbers typed into the keypad.
            break;

            case "Key":
            if(codeSequence.Length > 0)
            {
                CheckResults(); // When the player presses the key button, it will check to see if their sequence is correct.
            }
            break;
        }
    }

    private void DisplayCodeSequence(int digitJustEntered)
    {
        switch (codeSequence.Length)
        {
            case 1:
            characters[0].sprite = digits[10];
            characters[1].sprite = digits[10];
            characters[2].sprite = digits[10];
            characters[3].sprite = digits[digitJustEntered];
            break;

            case 2:
            characters[0].sprite = digits[10];
            characters[1].sprite = digits[10];
            characters[2].sprite = characters[3].sprite;
            characters[3].sprite = digits[digitJustEntered];
            break;

            case 3:
            characters[0].sprite = digits[10];
            characters[1].sprite = characters[2].sprite;
            characters[2].sprite = characters[3].sprite;
            characters[3].sprite = digits[digitJustEntered];
            break;

            case 4:
            characters[0].sprite = characters[1].sprite;
            characters[1].sprite = characters[2].sprite;
            characters[2].sprite = characters[3].sprite;
            characters[3].sprite = digits[digitJustEntered];
            break;

        }
    }

    private void CheckResults()
    {
        if (codeSequence == "0409") // The correct solution - uses the date on the movie posters.
        {
            Debug.Log("Correct!");
            correctEntered = true;
        }
        else // If anything else is typed & then the key button is pressed...
        {
            Debug.Log("Wrong!");
            ResetDisplay(); // Clears the numbers from the display so the player can type again.
        }
    }

    private void ResetDisplay() // Clears the numbers from the display so the player can type again.
    {
        for (int i = 0; i <= characters.Length - 1; i++)
        {
            characters[i].sprite = digits[10];
        }

        codeSequence = ""; // Replaces the numbers already typed with blank spaces.
    }
    
    private void OnDestroy() 
    {
        KeypadButtons.ButtonPressed -= AddDigitToCodeSequence;
    }
}
