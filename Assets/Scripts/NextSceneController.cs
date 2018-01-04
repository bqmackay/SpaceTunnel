using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneController : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("On Trigger Entered");
        SceneManager.LoadScene("Game");
    }

    public void Restart() {
        SceneManager.LoadScene(0);
    }
}
