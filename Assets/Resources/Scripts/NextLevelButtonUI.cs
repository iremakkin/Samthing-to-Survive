using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Summary:
// The function inside has a purpose to make the player go to next level on the Scene hierarchy.
// Its called when the player continue to next level by pressing Next Level button 
// which appears after pressed Control button and there is no seeds left outside of baskets.
public class NextLevelButtonUI : MonoBehaviour
{
    public void GoToNextLevel(){
        SceneController.instance.NextLevel();
    }
}
