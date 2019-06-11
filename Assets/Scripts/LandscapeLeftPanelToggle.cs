using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandscapeLeftPanelToggle: MonoBehaviour
{
    public GameObject LandscapeLeftPanel; // LandscapeLeftPanel GameObject is stored in variable LandscapeLeftPanel


    // Function to OPEN the LandscapeLeft Panel and play the open animation ; Happens when the INFO button is presed
    public void OpenLandscapeLeftPanel()
    {
        if (LandscapeLeftPanel != null) // Checks to see whether there is a GameObject attached TO PREVENT ERRORS
        {
            Animator LandscapeLeftPanelAnimator = LandscapeLeftPanel.GetComponent<Animator>(); // Get the animator controller component from the LandscapeLeft Panel game object and set it to an Animator variable for manipulation

            if (LandscapeLeftPanelAnimator != null) // Checks to see whether an Animator is present TO PREVENT ERRORS
            {
                LandscapeLeftPanelAnimator.SetBool("LandscapeLeftPanelOpen", true); // Set the LandscapeLeftPanelOpen boolean parameter(set in respective animator controller) to TRUE, triggering opening animation
            }
        }

    }

    // Function to CLOSE the LandscapeLeft Panel and play the closing animation ; Happens when the INFO-COLLAPSE button is presed
    public void CloseLandscapeLeftPanel()
    {
        if (LandscapeLeftPanel != null)
        {
            Animator LandscapeLeftPanelAnimator = LandscapeLeftPanel.GetComponent<Animator>(); // Get the animator controller component from the LandscapeLeft Panel game object and set it to an Animator variable for manipulation

            if (LandscapeLeftPanelAnimator != null) // Checks to see whether an animator is present TO PREVENT ERRORS
            {
                LandscapeLeftPanelAnimator.SetBool("LandscapeLeftPanelOpen", false); // Set the LandscapeLeftPanelOpen boolean parameter to FALSE, triggering closing animation
            }
        }
    }
}
