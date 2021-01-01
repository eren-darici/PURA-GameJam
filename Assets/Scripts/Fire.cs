using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    GameObject player;
    public GameObject projectile;
    public float projectileSpeed;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }


    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (player.GetComponent<SpriteRenderer>().flipX == false)
                
                Instantiate(projectile, transform.position, Quaternion.Euler(0,0,0)).GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0f);
            
            if (player.GetComponent<SpriteRenderer>().flipX == true)
                
                Instantiate(projectile, transform.position, Quaternion.Euler(0,180,0)).GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0f);

        }
        
    }

}
