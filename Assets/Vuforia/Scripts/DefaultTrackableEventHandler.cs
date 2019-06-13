/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;
using UnityEngine.UI;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
///
/// Changes made to this file could be overwritten when upgrading the Vuforia version.
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
/// 

// IMPORTANT! Code written by PTC Inc. and edited by Johnnathan Mak

public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    // CUSTOM VARIABLES to display Model Names
    public Text PortraitModelName;
    public Text LandscapeLeftModelName;
    public Text LandscapeRightModelName;

    // Text objects to display info onto
    public Text PortraitPanelText;
    public Text LandscapeLeftPanelText;
    public Text LandscapeRightPanelText;
    public TextAsset InformationFile;
    public Text InstructionsObject;
    private string InformationText;

    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;
    protected TrackableBehaviour.Status m_PreviousStatus;
    protected TrackableBehaviour.Status m_NewStatus;

    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    protected virtual void Start()
    {
        // Initialize trackableBehaviour component and event handler
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    protected virtual void OnDestroy()
    {
        // Unregister a given TrackableEventHandler
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    // Execute when Trackable state is changed
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        // Setting up variables
        m_PreviousStatus = previousStatus;
        m_NewStatus = newStatus;
        string DisplayModelName = mTrackableBehaviour.TrackableName; // Variable that stores the AR marker/model name
        string InformationText = InformationFile.text; // Initializes information text string to be displayed, by loading the respective Information text file into the variable
        string InfoInstructionText = InstructionsObject.text; // Info Instructions to be displayed when tracking marker is lost.

        // Checks the status of three different TrackableBehaviours and if conditions are met, execute the fucntions and procedures found nested within.
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found"); // Logs to console that a mTrackableBehaviour was found, and gives it's name.
            OnTrackingFound(); // Execute OnTrackingFound function defined below
            PortraitModelName.text = LandscapeLeftModelName.text = LandscapeRightModelName.text = DisplayModelName;// Make all canvas UI ModelName objects' text component = DisplayModelName
            PortraitPanelText.text = LandscapeLeftPanelText.text = LandscapeRightPanelText.text = InformationText; // Display info text on all text panels
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED && // If the conditions are met, execute the code nested within.
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost"); // Logs to console that a mTrackableBehaviour was lost, and gives it's name.
            OnTrackingLost(); // Execute OnTrackingLost function defined below
            PortraitModelName.text = LandscapeLeftModelName.text = LandscapeRightModelName.text = "Searching for Marker..."; // Make all canvas UI ModelName objects' text component = "Searching for Marker" string
            PortraitPanelText.text = LandscapeLeftPanelText.text = LandscapeRightPanelText.text = InfoInstructionText; // Make all canvas UI PanelText objects' text component InfoInstructionsText string

        }
        else // This 'else' statement is used to prevent errors
        {
            // ERROR TRAPPING
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
            PortraitModelName.text = LandscapeLeftModelName.text = LandscapeRightModelName.text = "Searching for Marker..."; // ERROR HANDLER Make all canvas UI ModelName objects' text component = "Searching for Marker" string ERROR HANDLER
            PortraitPanelText.text = LandscapeLeftPanelText.text = LandscapeRightPanelText.text = InfoInstructionText; // ERROR HANDLER Make all canvas UI PanelText objects' text component InfoInstructionsText string ERROR HANDLER
        }
    }

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound() // Enable all render compenents of AR Model to display
    {
        // Stores Render, Collider, and Cavas components into a variable
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);
        PlayOnStateChange player = GetComponentInChildren<PlayOnStateChange>(); // Inherit public class named PlayOnStateChange that plays audio

        // Enable rendering:
        foreach (var component in rendererComponents)
            component.enabled = true;

        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;

        player.Initialize(); // Execute Audio initializer function
        player.PlayOnAppear(); // Execute PlayOnAppear function to play audio
    }


    protected virtual void OnTrackingLost() // Disables all render compenents of AR Model on display
    {
        // Get all render components from a given object
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);
        PlayOnStateChange player = GetComponentInChildren<PlayOnStateChange>(); // Inherit public class named PlayOnStateChange that plays audio

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;

        player.PlayOnDisappear(); // Execute PlayOnAppear function to play audio
    }

    #endregion // PROTECTED_METHODS
}
