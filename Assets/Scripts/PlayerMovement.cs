using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRb;
    public float bounceForce = 6;

    private AudioManager audioManager;


    private void Start() {
        audioManager = FindObjectOfType<AudioManager>();
    }


    private void OnCollisionEnter(Collision other) {

        audioManager.Play("bounce");

        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);

        // Debug.Log(other.transform.GetComponent<MeshRenderer>().material.name);

        string materialName = other.transform.GetComponent<MeshRenderer>().material.name;

        if(materialName == "Safe (Instance)")
        {
            //the ball hit safe area
        } else if (materialName == "Unsafe (Instance)")
        {
            //the ball hits unsafe area
            // Debug.Log("Game Over!");
            audioManager.Play("game over");
            GameManager.gameOver = true;

        } else if (materialName == "LastRing (Instance)" && !GameManager.levelComplete)
        {
            //we completed the level

            GameManager.levelComplete = true;
            // Debug.Log("Level Completed");
            audioManager.Play("win level");
        }
        
    }
}
