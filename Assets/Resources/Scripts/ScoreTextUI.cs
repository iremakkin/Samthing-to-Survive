using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Summary:
// Adjust the Score Text on UI in-level. 
// The score shows how many seeds exit in the level and how many seeds are in place (this value gets updated).
public class ScoreTextUI : MonoBehaviour
{
    [SerializeField] private TMP_Text totalScoreText, _rightScoreText;
    private int totalScore, _rightScore=0;
    private GameObject[] seeds;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize components
        seeds = GameObject.FindGameObjectsWithTag("Seed");
        totalScoreText.text = seeds.Length.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the text which shows how many seeds placed
        _rightScoreText.text = _rightScore.ToString();
        ArrangeTextColor();
    }

    // Adjust the variable with the parameter
    // depending the state of when seed goes out/in on basket in plantController class. 
    public void RightScoreUpdate(bool isItRight){
        if(isItRight){
            _rightScore++;
        }else{
            _rightScore--;
        }
    }

    // Arrange the color of text that shows how many seeds are placed. 
    // Change the color to the green when all the seeds are placed on basket. 
    // Change it to the color grey if otherwise. 
    private void ArrangeTextColor(){
        if(seeds.Length == _rightScore){
            _rightScoreText.color = Color.green;
            totalScoreText.color = Color.green;
        }else{
            _rightScoreText.color = Color.white;
            totalScoreText.color = Color.white;
        }

    }
}
