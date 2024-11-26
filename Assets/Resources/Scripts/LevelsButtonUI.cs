using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// Summary:
// Lock the levels that the player hasn't reached yet in the level selection menu
// by getting the information from Player preferences.
public class LevelsButtonUI : MonoBehaviour
{
    public Button[] lvlButtons;

    // Start is called before the first frame update
    void Start()
    {
        // Get the stored Player preference about what level reached the player
        // Make each unreached level as uninteractable in level selection table
        int levelAt = PlayerPrefs.GetInt("levelAt", 5);
        Debug.Log(levelAt + " = level at");

        for (int i=0; i<lvlButtons.Length; i++){
            if (i+5 > levelAt){
                lvlButtons[i].GetComponent<Button>().interactable = false;
                Debug.Log(i + "numaralı level kiliti");
            }
       }
    }
 
}
