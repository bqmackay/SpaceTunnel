﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object
    public bool followPlayer;

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        Vector3 position = player.transform.position + offset;
        transform.position = position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (player == null) {
            return;
        }
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (!followPlayer)
        {
            Vector3 position = player.transform.position + offset;
            transform.position = position;
        } else {
            transform.position = player.transform.position - offset;
        }
    }
}
