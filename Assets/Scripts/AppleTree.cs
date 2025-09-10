using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    // Prefab for instantiating apples
    public GameObject applePrefab;
    public GameObject goldApplePrefab;
    public GameObject poisonApplePrefab; 

    // Speed at which the AppleTree moves
    public float speed = 10f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 24f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.02f;

    // Seconds between Apples instantiations
    public float appleDropDelay = 1f;
    
    void Start()
    {
        // Start dropping apples
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple;
        if (Random.Range(0, 6) == 0) // magic number to fix later
        {
            // 1 in 6 (recommended) chance for gold apple.
            apple = Instantiate<GameObject>(goldApplePrefab);
        }
        else if (Random.Range(0, 4) == 0)
        {
            // 1 in 4 recommended chance for poison apple. 
            apple = Instantiate<GameObject>(poisonApplePrefab); 
        }
        else
        {
            // Else it's regular apple. 
            apple = Instantiate<GameObject>(applePrefab);
        }
        // Move to position and invoke on delay. 
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }

    void Update()
    {
        // Basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        }
    }

    void FixedUpdate()
    {
        // Random direction changes are now time-based due to FixedUpdate()
        if (Random.value < changeDirChance)
        {
            speed *= -1; // Change direction
            // 50fps * 0.02chance = (50)(2/100) = 1 turn per sec
        }
    }
}
