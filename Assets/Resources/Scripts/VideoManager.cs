using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

// Summary:
// Manage the actions based on the video.
// Such as checking the video is over or not.
// The class includes an invoke method.
public class VideoManager : MonoBehaviour
{
    public GameObject continueButton, skipButton;

    // Start is called before the first frame update
    void Start()
    {
        // Invoke repeating to able to count the frames on the checkOver function
        InvokeRepeating("checkOver", 0.1f, 0.1f);
    }

    // Check the video is over or not, by counting the frames on repeat
    private void checkOver(){
       long playerCurrentFrame = gameObject.GetComponent<VideoPlayer>().frame+ 2;
       long playerFrameCount = System.Convert.ToInt64(gameObject.GetComponent<VideoPlayer>().frameCount);

       if(playerCurrentFrame < playerFrameCount)
       {
           print ("VIDEO IS PLAYING");
       }
       else
       {
           print ("VIDEO IS OVER");
           videoEnded();
       }
    }

    // Arrange the actions after the video playment.
    // Activate continue button and if skip button exits, set the skip button inactive.
    // Cancel the invoke repeating
    public void videoEnded(){
        if(!continueButton.activeInHierarchy){
            continueButton.SetActive(true);
        }
        if(skipButton.activeInHierarchy){
            skipButton.SetActive(false);
        }
        if(gameObject.GetComponent<VideoPlayer>().isPlaying){
            gameObject.GetComponent<VideoPlayer>().Stop();
        }
        CancelInvoke("checkOver");
    }
}
