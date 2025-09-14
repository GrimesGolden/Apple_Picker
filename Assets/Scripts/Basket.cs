using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    void Start()
    {
        // Find a GameObject named ScoreCounter in the scene hierarchy.
        GameObject scoreGO = GameObject.Find("ScoreCounter");

        // Get the ScoreCounter (Script) component out of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }
    void Update()
    {
        // Get the current screen position of the mouse from Input.
        Vector3 mousePos2D = Input.mousePosition;

        // The cameras z position sets how far to push the mouse into 3D
        // If this line causes a NullReferenceException, 
        // select the Main Camera in Hierarchy and set its tag to main cam in Inspector.
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game world space.
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the x position of this basket to the x position of the Mouse.
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        // Get the apple script from it (if possible)
        Apple apple = collidedWith.GetComponent<Apple>();

        if (collidedWith.CompareTag("Apple"))
        {
            // Get the class component
            if (apple.name == "PoisonApple(Clone)")
            // If the apple is poison act like an apple was missed. 
            {
                // Play the sound effect.
                FindObjectOfType<AudioManager>().Play("BugHit");
                // This is a simple way to get the ApplePicker script from the main camera. 
                ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
                // Now we can safely call apple missed. 
                apScript.AppleMissed();
            }
            else if (apple.name == "GoldenApple(Clone)")
            {   
                FindObjectOfType<AudioManager>().Play("GemHit");
                Destroy(collidedWith);
                // Increase the score
                // Use the points value from Apple class.
                scoreCounter.score += apple.points;
                HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
            }
            else if (apple.name == "Apple(Clone)")
            {
                FindObjectOfType<AudioManager>().Play("AppleHit");
                Destroy(collidedWith);
                scoreCounter.score += apple.points;
                HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
            }
        }
    }
}
