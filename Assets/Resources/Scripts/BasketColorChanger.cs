using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

// Summary:
// Changes the visual color of basket by changing the sprite of gameobject.
// The color depends on whether the seed is inside or outside from the basket.
// NOTE: A single basket is a combination of inside part and outside part. 
public class BasketColorChanger : MonoBehaviour
{
    public GameObject basket_outside; 
    private Sprite active_i, active_o, nonActive_i, nonActive_o;
    private SpriteRenderer spriteR_ins, spriteR_out;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize components
        // Load needed Sprites
        spriteR_out = basket_outside.GetComponent<SpriteRenderer>();
        spriteR_ins = gameObject.GetComponent<SpriteRenderer>();

        active_i = Resources.Load<Sprite>("Images/Baskets/sepetT_inside");
        nonActive_i =  Resources.Load<Sprite>("Images/Baskets/sepet_inside");
        active_o =  Resources.Load<Sprite>("Images/Baskets/sepetT_outside");
        nonActive_o =  Resources.Load<Sprite>("Images/Baskets/sepet_outside");

    }

    // Check if it triggers with Seed and change the Sprites to activated ones
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Seed"){
            spriteR_ins.sprite = active_i;
            spriteR_out.sprite = active_o;
              
        }
    }

    // Check if Seed exits the trigger and change the Sprites to inactive ones
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Seed"){
            spriteR_ins.sprite = nonActive_i;
            spriteR_out.sprite = nonActive_o;

        }
    }
    
}
