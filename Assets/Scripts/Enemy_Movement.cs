using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    GameObject [] adventurers;
    GameObject closest_obj;
    GameObject target;

    public string target_tag = "adventurer";
    public float movementSpeed = 1f; // Adjust this value to set the movement speed
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        adventurers = GameObject.FindGameObjectsWithTag(target_tag);
        rb2d = GetComponent<Rigidbody2D>();
    }

    GameObject findClosest()
    {
        float distance = Mathf.Infinity;
        Vector3 pos = transform.position;
        foreach (GameObject g in adventurers)
        {
            Vector3 diff = g.transform.position-pos;
            float currentDistance = diff.sqrMagnitude;
            if(currentDistance<distance)
            {
                closest_obj = g;
                distance = currentDistance;
            }
        }
        return closest_obj;
    }

    private void FixedUpdate() {
        if(target==null)
        {
            target = findClosest();
        }
        else
        {
            Vector3 direction = target.transform.position - transform.position;
            direction.z=0;
            direction.Normalize();
            direction = direction*movementSpeed;
            rb2d.velocity = new Vector2(direction.x, direction.y);
        }

    }
}
