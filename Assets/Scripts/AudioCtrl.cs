using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCtrl : MonoBehaviour
{
    public GameObject PortraitUnmutedIcon;
    public GameObject PortraitMutedIcon;

    public GameObject LandscapeLeftUnmutedIcon;
    public GameObject LandscapeLeftMutedIcon;

    public GameObject LandscapeRightUnmutedIcon;
    public GameObject LandscapeRightMutedIcon;

    public GameObject AudioListenerObject;

    void Start()
    {
    // Obsolete Code below commented out:
    // PortraitUnmutedIcon.SetActive(true);
    // PortraitMutedIcon.SetActive(false);

    // LandscapeLeftUnmutedIcon.SetActive(true);
    // LandscapeLeftMutedIcon.SetActive(false);

    // LandscapeRightUnmutedIcon.SetActive(true);
    // LandscapeRightMutedIcon.SetActive(false);
}

    public void ToggleAudio() //Toggle audio and mute/unmute icon function
    {

        bool AudioListenerObject_CurrentState = AudioListenerObject.activeSelf;
        AudioListenerObject.SetActive(!AudioListenerObject_CurrentState);

        // Get state of the unmute and mute icons for Portrait canvas as a bool, then switches the 'active-state' of the icons
        // to display one at a time, and let the user know that SFX is either ON or OFF.
        bool PortraitUnmutedIcon_CurrentState = PortraitUnmutedIcon.activeSelf;
        bool PortraitMutedIcon_CurrentState = PortraitMutedIcon.activeSelf;
            PortraitUnmutedIcon.SetActive(!PortraitUnmutedIcon_CurrentState);
            PortraitMutedIcon.SetActive(!PortraitMutedIcon_CurrentState);

        bool LandscapeLeftUnmutedIcon_CurrentState = LandscapeLeftUnmutedIcon.activeSelf;
        bool LandscapeLeftMutedIcon_CurrentState = LandscapeLeftMutedIcon.activeSelf;
            LandscapeLeftUnmutedIcon.SetActive(!LandscapeLeftUnmutedIcon_CurrentState);
            LandscapeLeftMutedIcon.SetActive(!LandscapeLeftMutedIcon_CurrentState);

        bool LandscapeRightUnmutedIcon_CurrentState = LandscapeRightUnmutedIcon.activeSelf;
        bool LandscapeRightMutedIcon_CurrentState = LandscapeRightMutedIcon.activeSelf;
            LandscapeRightUnmutedIcon.SetActive(!LandscapeRightUnmutedIcon_CurrentState);
            LandscapeRightMutedIcon.SetActive(!LandscapeRightMutedIcon_CurrentState);
    }
}
