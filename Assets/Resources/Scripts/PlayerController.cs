using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

// Summary:
// Manage the player movements.
// Show animations based on movements.
// Play audios of walking.
// This class will be used in-levels.
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public bool hasControlPressed = false, isMoving = false;
    private Animator anim; 
    public AudioSource soundSource;
    private Rigidbody2D rb;
    private Vector2 movement;
    private  SpriteRenderer spRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize components
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spRenderer = GetComponent<SpriteRenderer>();
        soundSource = GetComponent<AudioSource>();
        
        // Prevent the player from rotating
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the control button pressed
        if(!hasControlPressed){
            Move();
        }
    }

    void FixedUpdate()
    {
        // Apply movement to the player in FixedUpdate for physics consistency
        rb.velocity = movement * speed;
    }

    // Manages the player actions, managing three parts;
    // Movement part: Manage the moves the player
    // Animation part: Stop the current animation. Show needed animation 
    // Audio part: Manage the audio of player. Play walking sound if player is walking. Stop walking sound if player had stopped  
    void Move(){

        // Get player input from keyboard or controller
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Determine the priority of movement based on input, and act that way (this inc)
            if (horizontalInput != 0)
            {
                // Movement part
                movement = new Vector2(horizontalInput, 0);
                
                // Animation part
                anim.SetBool("RunBack", false);
                anim.SetBool("RunFront", false);
                anim.SetBool("RunSide", true);
                if(horizontalInput <0){
                    spRenderer.flipX = false; // running right
                }else{
                    spRenderer.flipX = true; // running left
                }

                // Audio part
                if(!soundSource.isPlaying){
                    soundSource.Play();
                }
                
            }
            else if (verticalInput != 0)
            {
                // Movement part
                movement = new Vector2(0, verticalInput);
                
                // Animation part
                anim.SetBool("RunSide", false);
                if(verticalInput > 0){
                    anim.SetBool("RunFront", false); // running up
                    anim.SetBool("RunBack", true);
                }else{
                    anim.SetBool("RunBack", false);
                    anim.SetBool("RunFront", true); // running down
                }

                 // Audio part
                if(!soundSource.isPlaying){
                    soundSource.Play();
                }
            }
            else{
                // Movement part
                movement = new Vector2(0,0);

                // Animation part
                anim.SetBool("RunSide", false);
                anim.SetBool("RunBack", false);
                anim.SetBool("RunFront", false);

                // Audio part
                if(soundSource.isPlaying){
                    soundSource.Stop();
                }
            }

    }

    // Stop player from moving when called
    public void StopPlayer(){
        hasControlPressed = true;
    }
        
}
