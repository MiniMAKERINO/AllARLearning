using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitPanelToggle: MonoBehaviour
{
    public GameObject PortraitPanel; // PortraitPanel GameObject is stored in variable Portrait Panel


    // Function to OPEN the Portrait Panel and play the open animation ; Happens when the INFO button is presed
    public void OpenPortraitPanel()
    {
        if (PortraitPanel != null) // Checks to see whether there is a GameObject attached TO PREVENT ERRORS
        {
            Animator PortraitPanelAnimator = PortraitPanel.GetComponent<Animator>(); // Get the animator controller component from the Portrait Panel game object and set it to an Animator variable for manipulation

            if (PortraitPanelAnimator != null) // Checks to see whether an animator is present TO PREVENT ERRORS
            {
                PortraitPanelAnimator.SetBool("PortraitPanelOpen", true); // Set the PortraitPanelOpen boolean parameter(set in respective animator controller) to TRUE, triggering opening animation
            }
        }

    }

    // Function to CLOSE the Portrait Panel and play the closing animation ; Happens when the INFO-COLLAPSE button is presed
    public void ClosePortraitPanel()
    {
        if (PortraitPanel != null)
        {
            Animator PortraitPanelAnimator = PortraitPanel.GetComponent<Animator>(); // Get the animator controller component from the Portrait Panel game object and set it to an Animator variable for manipulation

            if (PortraitPanelAnimator != null) // Checks to see whether an animator is present TO PREVENT ERRORS
            {
                PortraitPanelAnimator.SetBool("PortraitPanelOpen", false); // Set the PortraitPanelOpen boolean parameter to FALSE, triggering closing animation
            }
        }
    }
}
