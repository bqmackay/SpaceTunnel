using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour {

    private Rigidbody2D rb2d;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Vector2 movement = new Vector2(rb2d.position.x + moveHorizontal * PlayerController.speed, rb2d.position.y);


        Vector2 movement = new Vector2(moveHorizontal * PlayerController.speed, 0);
        //rb2d.AddForce(movement * speed);
        rb2d.MovePosition(rb2d.position + movement);

        //rb2d.MovePosition(movement);
    }


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
}
