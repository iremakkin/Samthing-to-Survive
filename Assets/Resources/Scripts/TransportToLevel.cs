using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

// Summary:
// Go to the next Scene on the Scene Hiearchy when the function inside called.
public class TransportToLevel : MonoBehaviour
{
    public void GoToLevel(string levelNo){
        SceneController.instance.LoadScene(levelNo);
    }
}
