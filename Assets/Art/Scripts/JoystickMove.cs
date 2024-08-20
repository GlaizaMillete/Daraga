using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickMove : MonoBehaviour
{
    public Joystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;

    private void Start() {
        
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {

        if(movementJoystick != null && movementJoystick.Direction.y != 0){

        rb.velocity = new Vector2(movementJoystick.Direction.x * playerSpeed, movementJoystick.Direction.y * playerSpeed);
        }
        {
        rb.velocity = Vector2.zero; // Use the null-conditional operator to avoid exception
    }
    }
}
