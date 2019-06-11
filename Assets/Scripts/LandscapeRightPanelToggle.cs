using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeRightPanelToggle: MonoBehaviour
{
    public GameObject LandscapeRightPanel; // LandscapeRightPanel GameObject is stored in variable LandscapeRightPanel


    // Function to OPEN the LandscapeRight Panel and play the open animation ; Happens when the INFO button is presed
    public void OpenLandscapeRightPanel()
    {
        if (LandscapeRightPanel != null) // Checks to see whether there is a GameObject attached TO PREVENT ERRORS
        {
            Animator LandscapeRightPanelAnimator = LandscapeRightPanel.GetComponent<Animator>(); // Get the animator controller component from the LandscapeRight Panel game object and set it to an Animator variable for manipulation

            if (LandscapeRightPanelAnimator != null) // Checks to see whether an Animator is present TO PREVENT ERRORS
            {
                LandscapeRightPanelAnimator.SetBool("LandscapeRightPanelOpen", true); // Set the LandscapeRightPanelOpen boolean parameter(set in respective animator controller) to TRUE, triggering opening animation
            }
        }

    }

    // Function to CLOSE the LandscapeRight Panel and play the closing animation ; Happens when the INFO-COLLAPSE button is presed
    public void CloseLandscapeRightPanel()
    {
        if (LandscapeRightPanel != null)
        {
            Animator LandscapeRightPanelAnimator = LandscapeRightPanel.GetComponent<Animator>(); // Get the animator controller component from the LandscapeRight Panel game object and set it to an Animator variable for manipulation

            if (LandscapeRightPanelAnimator != null) // Checks to see whether an animator is present TO PREVENT ERRORS
            {
                LandscapeRightPanelAnimator.SetBool("LandscapeRightPanelOpen", false); // Set the LandscapeRightPanelOpen boolean parameter to FALSE, triggering closing animation
            }
        }
    }
}
