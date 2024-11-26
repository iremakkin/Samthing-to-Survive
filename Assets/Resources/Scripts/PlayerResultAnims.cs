using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Summary:
// Manage the player's animation based on the result of level. 
// This class's functions will be called when Control button has pressed.
public class PlayerResultAnims : MonoBehaviour
{
    private Animator anim; 
    private GameObject[] seeds;
    private int wrongAns;
    private float timing;
    public bool isSamOnBasket = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize components
        seeds = GameObject.FindGameObjectsWithTag("Seed");
        anim = GetComponent<Animator>();
    }

    // Set the animation triggers based on the parameter (and by extra, the placement of the player)
    public void AnimateFinalSam(bool isItSuccess){
        if (isItSuccess){
            anim.SetTrigger("SamHappy");
        }else if(isSamOnBasket){
            anim.SetTrigger("SamTurningTree");
        }else{
            anim.SetTrigger("SamDead");
        }
    }

    // Check if Sam is staying on a basket, if so assign the bool true
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Basket"){
           isSamOnBasket = true;
        }
    }

    // Check if Sam is out from the basket, if so assign the bool false
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Basket"){
           isSamOnBasket = false;
        }
    }
}
