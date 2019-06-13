using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalLink : MonoBehaviour
{
    public void OpenHelp () // Function to open the help folder
    {
        Application.OpenURL("https://drive.google.com/drive/folders/1DMdMkN1YmzD7lWNpZHOsw4Y-xsiTngNW?usp=sharing"); // Open the URL to the help folder
    }
}
