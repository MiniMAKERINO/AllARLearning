using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCtrl : MonoBehaviour
{
    // This is a animation controller for the 3D models that toggles the animation when they are pressed on screen

    // Get the 3D model gameobject via the editor, hence public variable
    public GameObject AtomObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) // If there is a touch on screen
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); // Gets a Raycast from the camera and the location of touch input, and stores the raycast in a variable named ray.
            RaycastHit Hit; // Stores the RaycastHit into a variable named Hit
            if (Physics.Raycast(ray, out Hit)) // If Raycast or the 'touch' hits the 3D object, then executed the nested code
            {
                // Toggle animator component
                        Animator AtomAnimator = AtomObject.GetComponent<Animator>(); // get the animator from the 3D game object, in this case the Atom game object
                        bool OpenState = AtomAnimator.GetBool("play"); // Stores the boolean value of an animator component named 'play'(defined in the animator controller) into a variable
                        AtomAnimator.SetBool("play", !OpenState); // Sets the 'play' boolean to the opposite of what it is, meaning it toggles the animation

            }
        }
    }
}
