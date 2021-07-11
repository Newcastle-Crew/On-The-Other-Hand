using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    Rigidbody rb; // Variable for the rigidbody code to use.
    [SerializeField] float playerSpeed = 2.0f; // Sets the player' speed value - can be edited in the 'inspector' thingy.
    [SerializeField] float sprintMultiplier = 1.5f; // Sets a 'sprint' speed that multiplies the player's regular speed by 1.5 (and can be tweaked by the editor)
    #endregion
    private void Start() /// Start is called before the first frame update
    {
        rb = GetComponent<Rigidbody>(); // Gives the player the ability to physically interact with objects.
    }

    void Update()
    {

    float x = Input.GetAxisRaw("Horizontal");
    float z = Input.GetAxisRaw("Vertical");
    Vector3 moveBy = transform.right * x + transform.forward * z;

    float actualSpeed = playerSpeed; // Makes it possible to sprint by having an extra speed variable.
    if (Input.GetKey(KeyCode.LeftShift)) // Holding down the Left Shift key makes the player move 1.5x faster.
    {
        actualSpeed *= sprintMultiplier;
    }
    rb.MovePosition(transform.position + moveBy.normalized * actualSpeed * Time.deltaTime); // Stops movement from being choppy by using framerate.
    }
}