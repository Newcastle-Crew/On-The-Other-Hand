using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private float typewriterSpeed = 40f; // The speed at which the text appears; tweakable in the inspector.

    private readonly Dictionary<HashSet<char>, float> punctuations = new Dictionary<HashSet<char>, float>() // Will make text pause when certain punctuation appears in-text.
    {
        {new HashSet<char>(){'.','!','?',}, 0.6f},
        {new HashSet<char>(){',',';',':','"'}, 0.3f},
    };

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
            int lastCharIndex = charIndex;

            t += Time.deltaTime * typewriterSpeed; // Increments over time.
            charIndex = Mathf.FloorToInt(t); // Stores the 'floor' value of the timer without the decimal point.
            charIndex = Mathf.Clamp(value:charIndex, min:0, max:textToType.Length);

            for(int i = lastCharIndex; i < charIndex; i++)
            {
                bool isLast = i >= textToType.Length - 1;

                textLabel.text = textToType.Substring(startIndex:0, length:i + 1);

                if (IsPunctuation(textToType[i], out float waitTime) && !isLast && !IsPunctuation(textToType[i + 1], out _)) // Is the character punctuation? if so, wait
                {
                    yield return new WaitForSeconds(waitTime);
                }
            }

            textLabel.text = textToType.Substring(startIndex:0,length:charIndex); // Stops the game from displaying too many words

            yield return null;
        }

        textLabel.text = textToType;
    }

    private bool IsPunctuation(char character, out float waitTime)
    {
        foreach (KeyValuePair <HashSet<char>, float> punctuationCategory in punctuations)
        {
                if (punctuationCategory.Key.Contains(character))
                {
                    waitTime = punctuationCategory.Value;
                    return true;
                }
        }

        waitTime = default;
        return false;
    }
    
}
