using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{

    public float maxHealth;
    public float range; //Attack range
    public float damage; //Base damage
    public float attack_delay=1f;
    public float armor_modifier=1; //0(full)-1(none) incomming damage modifier
    public float movement_speed=1;
    public int allowable_deaths=1; 
    public string target_tag; //Tag of creatures that this one should target
    public bool fighting=true; //If the creature is active or not

    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Activate creature and start combat
    void Start_Combat()
    {
        fighting=true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
