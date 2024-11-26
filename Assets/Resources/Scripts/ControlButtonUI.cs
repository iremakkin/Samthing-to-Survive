using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Summary:
// Control what happens when the control button pressed. 
// This class includes the actions such as adding the animations, calling the functions of arranging buttons,
// stops the player, show the specific texts due to the resulf of level completion.
public class ControlButtonUI : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;
    private GameObject[] seeds;
    private GameObject player, buttonController;
    public AudioSource rightSound, wrongSound;
    private int wrongAns;
    private bool HasAlreadyClicked = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // Initialize components
        seeds = GameObject.FindGameObjectsWithTag("Seed");
        player = GameObject.FindGameObjectWithTag("Player");
        buttonController = GameObject.FindGameObjectWithTag("ButtonController");
    }

    public void PlantAnimate(){
        // Animate the final form of each seed
        foreach(GameObject seed in seeds){
            seed.GetComponent<PlantController>().ShowPlantAnimation();
        }
    }

    public void ShowResults(){

        // Count the wrong placed seeds. Depending of seed count, add result text and needed sound effects. 
        if (!HasAlreadyClicked){
            foreach(GameObject seed in seeds){
                if(!seed.GetComponent<PlantController>().Result()){
                    wrongAns++;
                }
            }

            if(wrongAns == 0){
                resultText.text = "Wow You did it!!\n Sam now will not entirely starve in the scary space!\nLet's plant more to other rooms and secure Sam's safety!";
                player.GetComponent<PlayerResultAnims>().AnimateFinalSam(true);
                buttonController.GetComponent<ButtonController>().ActivateNextButton();
                rightSound.Play();

            }else if(player.GetComponent<PlayerResultAnims>().isSamOnBasket){
                resultText.text = "W-w-what have you done..\nOh no... Sam...no, no....";
                player.GetComponent<PlayerResultAnims>().AnimateFinalSam(false);
                wrongSound.Play();

            }else{
                resultText.text = "What have you done!!?\nRestart immediatly! And turn Sam back to life,\n(but please dont tell Sam about this..)\nWell, also dont foget "+ wrongAns +" plant/s again";
                player.GetComponent<PlayerResultAnims>().AnimateFinalSam(false);
                wrongSound.Play();
            }

            HasAlreadyClicked = true;
        }
    }

    // Stop player from moving after pressed control
    public void StopPlayer(){
        player.GetComponent<PlayerController>().hasControlPressed = true;
    }

}
