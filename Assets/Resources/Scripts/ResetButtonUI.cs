using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Summary:
// Resets the current level and activates the control button if its disabled.
// This class will be called when the player wants the reset the current level
// by clicking the Reset Button on the level.
public class ResetButtonUI : MonoBehaviour
{
    private GameObject obj;
    private void Start() {
        obj = this.gameObject;
    }
    public void ResetLevel(){
        obj.GetComponent<ButtonController>().ActivateControlButton();
        SceneController.instance.RestartLevel();
    }
}
