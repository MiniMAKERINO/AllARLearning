using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOrientation : MonoBehaviour
{
    // Get game objects to manipulate, in this case to turn on or off
    [SerializeField] private GameObject PortraitCanvas;
    [SerializeField] private GameObject LandscapeLeftCanvas;
    [SerializeField] private GameObject LandscapeRightCanvas;

    // Update is called once per frame
    void Update() // Using update to constantly check for screen orientation
    {
        // Check if screen orientation is portrait.
        if (Screen.orientation == ScreenOrientation.Portrait) {
            
            // If screen orientation IS Portrait, then set the Portrait Canvas to Active.
            PortraitCanvas.SetActive(true);

            // Deactivate/Turn off the LandscapeLeft and LandscapeRight canvases
            LandscapeLeftCanvas.SetActive(false);
            LandscapeRightCanvas.SetActive(false);
        }

        if (Screen.orientation == ScreenOrientation.LandscapeLeft)
        {
            // If screen orientation IS LandscapeLeft, then set the LandscapeLeft Canvas to Active.
            LandscapeLeftCanvas.SetActive(true);

            // Deactivate/Turn off the LandscapeRight and Portrait canvases
            PortraitCanvas.SetActive(false);
            LandscapeRightCanvas.SetActive(false);
        }

        if (Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            // If screen orientation IS LandscapeRight, then set the LandscapeRight Canvas to Active.
            LandscapeRightCanvas.SetActive(true);

            // Deactivate/Turn off the LandscapeLeft and Portrait canvases
            PortraitCanvas.SetActive(false);
            LandscapeLeftCanvas.SetActive(false);
        }
    }
}
