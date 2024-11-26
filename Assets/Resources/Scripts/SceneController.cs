using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

// Summary:
// Manage all the scene actions.
// It includes the actions such as; go to a specific level, restart the current level 
// or go to the next level depending of the Scene hierarchy.
public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public int nextSceneLoad;

    private void Awake() {
        if(instance == null){
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }else{
            //Destroy(gameObject);
        }
    }

    // Go to the next Scene depending of the Scene hiearchy, also
    // Check and Update the last level that player reached
    public void NextLevel(){
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadSceneAsync(nextSceneLoad);
        
        if(nextSceneLoad > PlayerPrefs.GetInt("levelAt")){
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }
    }

    // Restart the current Scene
    public void RestartLevel(){
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    // Load the specific Scene with the given parameter
    public void LoadScene(string sceneName){
        SceneManager.LoadSceneAsync(sceneName);
    }
}
