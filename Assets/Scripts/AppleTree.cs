using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]

    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Speed at which the AppleTree moves
    public float speed = 10f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 24f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    // Seconds between Apples instantiations
    public float appleDropDelay = 1f;

    void Start()
    {
        // Start dropping apples
    }

    void Update()
    {
        // Basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos; 
        // Changing Direction
    }
}
