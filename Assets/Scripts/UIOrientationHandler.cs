using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOrientationHandler : MonoBehaviour
{

    public GameObject PortraitCanvas;
    public GameObject LandscapeLeftCanvas;
    public GameObject LandscapeRightCanvas;

    // Update is called once per frame
    void Update()
    {
        if (Screen.orientation == ScreenOrientation.Portrait) {
            PortraitCanvas.SetActive(true);

            LandscapeLeftCanvas.SetActive(false);
            LandscapeRightCanvas.SetActive(false);
        }

        if (Screen.orientation == ScreenOrientation.LandscapeLeft)
        {
            LandscapeLeftCanvas.SetActive(true);

            PortraitCanvas.SetActive(false);
            LandscapeRightCanvas.SetActive(false);
        }

        if (Screen.orientation == ScreenOrientation.LandscapeRight)
        {
            LandscapeRightCanvas.SetActive(true);

            PortraitCanvas.SetActive(false);
            LandscapeLeftCanvas.SetActive(false);
        }
    }
}
