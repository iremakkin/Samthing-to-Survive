using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Summary:
// Quit the application directly if called.
// The function inside will be called when the player wants to quit the game
// by clicking the Quit Button on the Main Menu.
public class QuitButtonUI : MonoBehaviour
{
    public void ExitGame() {
        Application.Quit();
    }
}
