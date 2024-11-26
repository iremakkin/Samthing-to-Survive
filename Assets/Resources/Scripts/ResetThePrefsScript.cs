using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Summary:
// Delete all the player preferences if called.
// This class will be called when creating a new game 
// by clicking the play button on the main menu.
public class ResetThePrefsScript : MonoBehaviour
{
    public void DeletePlayerPrefs(){
        PlayerPrefs.DeleteAll();
    }
}
