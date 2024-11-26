using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Summary:
// Set the actions of the seeds in-level and show the specific results when control button is pressed.
// This includes adjustments suchs as sounds, animatics, etc..
public class PlantController : MonoBehaviour
{
    private bool isInPlace = false;
    private Rigidbody2D rb;
    private Animator anim;
    private GameObject scoreButton;
    public AudioSource activateSnd, deActivateSnd;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize components
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scoreButton = GameObject.FindGameObjectWithTag("ButtonController");

        // Prevent the seed from rotating
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Set the triggers of animations,
    // Depending on the place where the seed is standing
    public void ShowPlantAnimation(){

        if (isInPlace){
            anim.SetTrigger("GrowGood");
        }
        else{
            anim.SetTrigger("GrowBad");
        }
    }

    // Returns the state of seed's place as boolean
    public bool Result(){
        return isInPlace;
    }

    // Check if the seed is standing on basket
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Basket"){   
            ChangeScoringAndPlayAudio(true);
            
        }
    }
    
    // Check if the seed had separated from basket
    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Basket"){
            ChangeScoringAndPlayAudio(false);
            
        }
        
    }

    // Arranges the bool variable named "isInPlace" comparing the given parameter
    // Add sound depending on parameter which in situtations such as seed went inside/outside of the basket 
    private void ChangeScoringAndPlayAudio(bool current){
        if(isInPlace != current){
            isInPlace = current;
            scoreButton.GetComponent<ScoreTextUI>().RightScoreUpdate(isInPlace);
            if(current){
                activateSnd.Play();
            }else{
                deActivateSnd.Play();
            }
        }
        
    }
    
}
