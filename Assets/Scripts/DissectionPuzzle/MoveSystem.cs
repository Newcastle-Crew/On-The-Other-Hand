using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : MonoBehaviour
{
    public GameObject correctForm;
    private bool moving; // Will check if an animal part is being moved or not.
    private float startposX;
    private float startposY;


    void Start() // Start is called before the first frame update
    {
        
    }

    
    void Update() // Update is called once per frame
    {
        if (moving) // If left click is being held down...
        {
            Vector3 mousePos; // Keeps track of where the mouse is with a vector 3.
            mousePos = Input.mousePosition; 
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startposX, mousePos.y - startposY, this.gameObject.transform.localPosition.z);
        }
    }

    private void OnMouseDown() // Starts moving the animal part when the player holds the mouse down on it.
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos; // Keeps track of where the mouse is.
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startposX = mousePos.x - this.transform.localPosition.x;
            startposY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }  

    }

    private void OnMouseUp() 
    {
        moving = false; // Stops moving the animal part when the player isn't clicking.
    }
}
