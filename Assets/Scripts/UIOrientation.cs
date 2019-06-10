using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOrientation : MonoBehaviour
{

    [SerializeField] private GameObject PortraitCanvas;
    [SerializeField] private GameObject LandscapeLeftCanvas;
    [SerializeField] private GameObject LandscapeRightCanvas;

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
