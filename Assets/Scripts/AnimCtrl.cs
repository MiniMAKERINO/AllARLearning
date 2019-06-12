using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCtrl : MonoBehaviour
{
    string ButtonName;
    public GameObject AtomObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if (Physics.Raycast(ray, out Hit))
            {
                //ButtonName = Hit.transform.name;
               // switch (ButtonName) // Using switch can be used with multiple objects for adding future models
              //  {
                  //  case "AtomFinal":
                        Animator AtomAnimator = AtomObject.GetComponent<Animator>();
                        bool OpenState = AtomAnimator.GetBool("play");
                        AtomAnimator.SetBool("play", !OpenState);
                       // break;
                 //   default:
                  //      break;
               // }
            }
        }
    }
}
