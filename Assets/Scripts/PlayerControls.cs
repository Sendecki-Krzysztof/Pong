using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public float speed = 10.0f;
    public float maxY = 2.25f;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    /*
     * Checks the Direction that the player wants to go by looking at key presses. 
     * Up is postive speed in the y direction Down is negative speed in the y direction. 
     */
    void checkPlayerDirection()
    {

        var velocity = rb2d.velocity;

        if (Input.GetKey(up)) {
            if (velocity.y < speed) {
                velocity.y++;
            }
        }
        else if (Input.GetKey(down)) {
            if (velocity.y > -speed)
            {
                velocity.y--;
            }
        }
        else {
            velocity.y = 0;
        }
        rb2d.velocity = velocity;
    }

    /*
     * Keeps the player bound within the given max for the Y direction
     */
    void checkBoundPlayer() {
        var pos = transform.position;

        if (pos.y > maxY) {
            pos.y = maxY;
        }
        else if (pos.y < -maxY) {
            pos.y = -maxY;
        }
        transform.position = pos;
    }



    // Update is called once per frame
    void Update()
    {
        checkPlayerDirection();
        checkBoundPlayer();
    }


   
}
