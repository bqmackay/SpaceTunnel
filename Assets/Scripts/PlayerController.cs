using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public static float speed = 0.2f;
    public Rigidbody2D laser;
    public float laser_speed;
    public GameObject cannon;
    private int score;
    public Text scoreText;
    public Text winText;

    private bool movable = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("On Trigger");
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Enemy") {
            Destroy(gameObject);
            winText.text = "You Lose :(";
        } else if (other.gameObject.tag == "Goal") {
            winText.text = "You Win :)";
            movable = false;
            Destroy(other.gameObject);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject e in enemies) {
                EnemyController controller = e.GetComponent<EnemyController>();
                controller.DestroyEnemy();
            }
        }
    }

    void FixedUpdate()
    {
        if (!movable) {
            return;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        if (moveHorizontal > 0) {
            rb2d.rotation = 90;
        } else if (moveHorizontal < 0) {
            rb2d.rotation = -90;
        }
        //rb2d.AddForce(movement * speed);
        rb2d.MovePosition(rb2d.position + (movement * speed));
    }

    void Update() {
        if (!movable) {
            return;
        }
        if (Input.GetKeyDown("space"))
        {
            FireLaser();
        }

    }

    private void FireLaser() {
        Rigidbody2D laserClone = (Rigidbody2D)Instantiate(laser, cannon.transform.position, laser.transform.rotation);
        if (rb2d.rotation == 90) {
            laserClone.velocity = new Vector2(laser_speed, 0);    
        } else {
            laserClone.velocity = new Vector2(-laser_speed, 0);    
        }

    }

    public void AddKillToScore() {
        score = score + 1000;
        setScore();
    }

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true;
        score = 0;
        setScore();
        winText.text = "";
    }

    private void setScore() {
        Debug.Log("Score: " + score.ToString());
        scoreText.text = "Score: " + score.ToString();
    }
}
