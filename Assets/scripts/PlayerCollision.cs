using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public GameManager gameManager;

    private void Awake() {
        gameManager = FindObjectOfType<GameManager>();
    }
    void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Obstacle") {
            movement.enabled = false;
            gameManager.EndGame();
        } else if (other.collider.tag == "PowerUp") {
            gameManager.PowerUpPlayerFor(10.0f);
            Destroy(other.gameObject);
        } else {
            Debug.Log("Collided with " + other.collider.name);
        }
    }
}
