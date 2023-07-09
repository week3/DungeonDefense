using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public string monsterTag,adventurerTag;
    public List<GameObject> objectsInRoom = new List<GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {
        List<Collider2D> collidersInRoom = new List<Collider2D>();
        List<GameObject> allObjects = new List<GameObject>();
        Physics2D.OverlapCollider(GetComponent<Collider2D>(),new ContactFilter2D(), collidersInRoom);
        foreach (Collider2D c in collidersInRoom)
        {
            if(!allObjects.Contains(c.gameObject))
            {
                allObjects.Add(c.gameObject);
            }
        }
        foreach (GameObject g in allObjects)
        {
            if(g.tag==monsterTag||g.tag==adventurerTag)
            {
                objectsInRoom.Add(g);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
