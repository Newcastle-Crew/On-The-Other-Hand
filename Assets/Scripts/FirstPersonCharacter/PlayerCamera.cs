using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{    
    [SerializeField] Transform cam; // Camera variable, only modifiable by this script and tweakable in the Inspector thingy.
    [SerializeField] float sensitivity; // Variable for how quickly the player's vision can spin around. Tweakable.
    float headRotation = 0f; // Keeps track of how much the mouse has moved. Not tweakable.
    [SerializeField] float headRotationLimit = 90f; // Stops the player from being able to look behind themself. Tweakable.
    
    void Start() /// Start is called before the first frame update
    {
        Cursor.visible = false; // Makes the cursor invisible so it doesn't distract the player.
        Cursor.lockState = CursorLockMode.Locked; // Keeps the mouse centered in the game.
    }

    
    void Update() /// Update is called once per frame
    {
        float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime * -1f;

        transform.Rotate(0f, x, 0f);

        headRotation += y;
        headRotation = Mathf.Clamp(headRotation, -headRotationLimit, headRotationLimit); // Stops the player from being able to see behind themselves.
        cam.localEulerAngles = new Vector3(headRotation, 0f, 0f);
    }
}
