using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Summary:
// Change the activeness of the buttons in hierarchy when the functions get called.
public class ButtonController : MonoBehaviour
{
    public GameObject nextB, controlB;

    // Activate next button, De-activate control button
    public void ActivateNextButton(){
        if(!nextB.activeInHierarchy){
            nextB.SetActive(true);
        }
        if(controlB.activeInHierarchy){
            controlB.SetActive(false);
        }
    }

    // Activate control button, De-activate next button
    public void ActivateControlButton(){
        if(nextB.activeInHierarchy){
            nextB.SetActive(false);
        }
        if(!controlB.activeInHierarchy){
            controlB.SetActive(true);
        }
    }

}
