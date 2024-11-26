using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Summary:
// Activate or inactivate Pop-up messages depending of the current state.
// Adjust the main menu buttons
// by making them uninteractable when pop-up message is showing or making them interactable when pop-up message disappeared.
public class MainMenuWindowController : MonoBehaviour
{
    public Button[] mainMenuButtons;

    // Check if the gameobject on parameter active or inactive
    // Set their active state as opposite
    public void ActivateOrDeactivateWindow(GameObject window){
        if(!window.activeInHierarchy){
            window.SetActive(true);
        }else{
            window.SetActive(false);
        }
    }

    // Activate the buttons on the main menu when called
    public void Activate_MenuButtons(){
        foreach(Button mainMenubutton in mainMenuButtons){
            mainMenubutton.GetComponent<Button>().interactable = true;
        }
    }

    // Inactivate the buttons on the main menu when called
    public void DeActivate_MenuButtons(){
        foreach(Button mainMenubutton in mainMenuButtons){
            mainMenubutton.GetComponent<Button>().interactable = false;
        }
    }

}
