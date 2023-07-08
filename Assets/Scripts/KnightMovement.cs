using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour
{
    public float movementSpeed = 5f; // Adjust this value to set the movement speed
    public float maxHealth = 10f;
    private float currentHealth;
    public Transform healthbarTransform;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //Map physics object
        currentHealth=maxHealth;
    }
    private void FixedUpdate()
    {
        handleMovement();
        updateHealth();
    }

    //Movement handler called every game tick
    //Velocity direction handled by wasd for debugging
    private void handleMovement()
    {
        float horizontalInput = Input.GetAxis("Vertical");
        float verticalInput = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(verticalInput*movementSpeed,horizontalInput*movementSpeed);
    }

    //Health handler called every game tick
    private void updateHealth()
    {
        Vector3 localScale = healthbarTransform.localScale;
        healthbarTransform.localScale =new Vector3(currentHealth/maxHealth,localScale.y,localScale.z); //Set healthbar scale to the percent of health left
    }

    //Function other objects can call to apply damage. Has to be named this exactly
    public void ApplyDamage(float damage)
    {
        currentHealth-=damage;
        if(currentHealth<0)
        {
            currentHealth=0;
        }
        updateHealth();
    }
}
