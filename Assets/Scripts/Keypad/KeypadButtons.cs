#region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
#endregion

public class KeypadButtons : MonoBehaviour
{
    public static event Action <string> ButtonPressed = delegate { };

    private int dividerPosition; // The divider is... TODODODODOD
    private string buttonName, buttonValue;
    
    void Start() // Start is called before the first frame update
    {
        buttonName = gameObject.name; // The button's name will be identical to the name of the object its code is attached to.
        dividerPosition = buttonName.IndexOf("_");
        buttonValue = buttonName.Substring(0, dividerPosition); // the button's value will be identical to its name?

        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClicked); // Runs the ButtonClicked method whenever a button is clicked.
    }

    private void ButtonClicked() // Used to tell buttons apart.
    {
        ButtonPressed(buttonValue); // Lets the game know exactly which button was pressed based on its value.
    }
}
