using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    GameObject [] adventurers;
    GameObject closest_obj;
    GameObject target;

    public string target_tag = "adventurer";
    public float range = 1.5f;
    private float rangeSquared;
    public bool showRange = true;
    public float attackDelay = 2f; //Seconds between attacks
    public float damage = 0.5f;

    private float debounceRangeSquared; //90% of attack range. Where the enemy will stop
    private float nextAttackTime=0f; //minimum clock time till next attack

    public Transform rangeOverlay;
    public float movementSpeed = 1f; // Adjust this value to set the movement speed
    private Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {
        adventurers = GameObject.FindGameObjectsWithTag(target_tag);
        rb2d = GetComponent<Rigidbody2D>();
        rangeSquared=range*range;
        debounceRangeSquared=square(range*0.9f);
        setRangeOverlay();

    }

    private void FixedUpdate() 
    {
        handleMovement();
        handleAttack();
    }

    private GameObject findClosest()
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

    //Called every game tick
    //Moves enemy to closest target
    private void handleMovement()
    {
        if(target==null)
        {
            target = findClosest();
        }
        else
        {
            Vector3 direction = target.transform.position - transform.position;
            direction.z=0;
            if(direction.sqrMagnitude>debounceRangeSquared)
            {
                direction.Normalize();
                direction = direction*movementSpeed;
                rb2d.velocity = new Vector2(direction.x, direction.y);
            }
            else
            { 
                Debug.Log("In range");
                rb2d.velocity = new Vector2(0,0);
            }
        }
    }

    private float square(float num)
    {
        return num*num;
    }

    private void setRangeOverlay()
    {
        float scale;
        if(showRange)
            scale=range*2;
        else
            scale=0f;
        
        Vector3 localScale = rangeOverlay.localScale;
        rangeOverlay.localScale =new Vector3(scale,scale,localScale.z); //Set healthbar scale to the percent of health left
    }

    //Get the squared distance from this object to the other
    //SQRT function is very slow. So just compare to the squared distance
    private float getSquareDistance2D(Vector3 v)
    {
        Vector3 distance = transform.position - v;
        distance.z=0;
        return distance.sqrMagnitude;
    }

    private void handleAttack()
    {
        if(target != null)
        {
            float currentTime=Time.time;
            if(currentTime>nextAttackTime)
            {
                if(getSquareDistance2D(target.transform.position)<=rangeSquared)
                {
                    nextAttackTime=currentTime+attackDelay;
                    target.SendMessage("ApplyDamage",damage);
                }
            }
        }
    }
}
