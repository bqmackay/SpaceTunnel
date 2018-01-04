using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject player;
    public float pursuitDistance;
    public float speed;

    // Use this for initialization
    void Start()
    {
        
    }

	// Update is called once per frame
	void Update () {
		
	}

    public void DestroyEnemy() {
        //Stops pursuit
        pursuitDistance = -1;
    }

    private void FixedUpdate()
    {
        //transform.LookAt(player.transform);
        if (player == null) {
            return;
        }
        RaycastHit2D raycast = Physics2D.Linecast(transform.position, player.transform.position, 1<<8);
        if (raycast.collider == null)
        {
            ShouldPursue();
        }
    }

    void ShouldPursue() {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= pursuitDistance) {
            Pursue();
        }
    }

    void Pursue()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
}
