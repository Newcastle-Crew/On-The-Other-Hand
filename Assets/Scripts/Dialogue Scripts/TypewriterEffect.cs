using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private float typewriterSpeed = 20f; // The speed at which the text appears; tweakable in the inspector.

    public Coroutine Run(string textToType, TMP_Text textLabel) 
    {
        return StartCoroutine (routine: TypeText(textToType, textLabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        textLabel.text = string.Empty; // Makes sure there's nothing in the box before playing text.

        float t = 0;
        int charIndex = 0; // Will measure how many 'characters' (letters and numbers) are on screen

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * typewriterSpeed; // Increments over time.
            charIndex = Mathf.FloorToInt(t); // Stores the 'floor' value of the timer without the decimal point.
            charIndex = Mathf.Clamp(value:charIndex, min:0, max:textToType.Length);

            textLabel.text = textToType.Substring(startIndex:0,length:charIndex); // Stops the game from displaying too many words

            yield return null;
        }

        textLabel.text = textToType;
    }

}
