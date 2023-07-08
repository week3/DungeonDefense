using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    public float movementSpeed = 5f; // Adjust this value to set the movement speed
    private Rigidbody2D rb2d;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Vertical");
        float verticalInput = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(verticalInput*movementSpeed,horizontalInput*movementSpeed);
    }
}
