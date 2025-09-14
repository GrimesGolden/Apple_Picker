using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public static float bottomY = -20f;
    public int points = 100; // Useful for golden apples
    public bool isPoison = false; // Useful for poison apples. 

    void Update()
    {   
        // If this apple reaches the bottom of the screen and it's not poison. 
        if (transform.position.y < bottomY && !isPoison)
        {   
            // Destroy it. 
            Destroy(this.gameObject);

            //Get the our audio manager class using find object, then use the Play method using the sounds effect string name; 
            // Play the associate sound effect. 
            FindObjectOfType<AudioManager>().Play("BasketLost");

            // Get a reference to the ApplePicker component of Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // Call the public AppleMissed() method of apScript
            apScript.AppleMissed();
        }
    }
}
