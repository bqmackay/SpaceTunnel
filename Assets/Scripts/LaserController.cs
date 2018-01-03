using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            GameObject player = GameObject.Find("spaceship_2");
            PlayerController controller = player.GetComponent<PlayerController>();
            controller.AddKillToScore();
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
