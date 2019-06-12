using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnStateChange : MonoBehaviour
{
    // Setting up audio variables
    public AudioClip AppearClip;
    public AudioClip DisappearClip;

    private AudioSource source;

    // Execute on awake
    private void Awake()
    {
        source = GetComponent<AudioSource>(); // Get Audio source component
        source.enabled = false; // Make the component false on awake to prevent errors and unwanted audio outcomes
    }

    public void Initialize()
    {
        source.enabled = true;
    }

    public void PlayOnAppear()
    {
        source.clip = AppearClip;
        source.Play();
    }

    public void PlayOnDisappear()
    {
        source.clip = DisappearClip;
        source.Play();
    }
}
