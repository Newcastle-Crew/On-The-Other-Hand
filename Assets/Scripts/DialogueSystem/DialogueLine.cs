using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private Text textHolder; // The box that holds the text.
        [SerializeField] private string input; // The text box's text - tweakable in Unity.

        private void Awake() 
        {
            {
                textHolder = GetComponent<Text>();

                StartCoroutine(WriteText(input,textHolder));
            }
        }
    }

}