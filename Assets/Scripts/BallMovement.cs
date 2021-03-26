using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int ballBounces = 0;
    private AudioSource source;

    /*
     * Randomly picks the balls direction at the start of the game
     */
    void ballDirection() {
        float rand = Random.Range(0, 2);
        int randDirection = Random.Range(1, 10);
        if (rand < 1) {
            rb2d.AddForce(new Vector2(25, randDirection));
        }
        else {
            rb2d.AddForce(new Vector2(-25, -randDirection));
        }
    }

    // Resets the ball back to the center of the feild.
    void resetBall() {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        ballBounces = 0;
    }

    // Starts the game over
    void resetGame() {
        resetBall();
        Invoke("ballDirection", 1);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.CompareTag("Player")) {
            Vector2 vel;
            vel.x = rb2d.velocity.x + ballBounces;
            vel.y = (rb2d.velocity.y / 2) + (col.collider.attachedRigidbody.velocity.y / 3) + ballBounces;
            rb2d.velocity = vel;
            ballBounces++;
        }

        source.Play();
    }


    // Start is called before the first frame update
    void Start() {
        source = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("ballDirection", 1);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
