using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxcol2d;
    Vector2 firstPos;
    Collision2D collision;
    GameObject player;


    GameObject Heart1;
    GameObject Heart2;
    GameObject Heart3;
    GameObject respawnPoint;
    GameObject deathLayer;
    public bool isPlayerInScene = true;
    public int health = 3;

    public string gameOver;


    public bool dir = true; // left 0 right 1
    public float laserLength = 3f;
    public float movementSpeed = 1f;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxcol2d = GetComponent<BoxCollider2D>();
        firstPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");

        Heart1 = GameObject.FindGameObjectWithTag("HP1");
        Heart2 = GameObject.FindGameObjectWithTag("HP2");
        Heart3 = GameObject.FindGameObjectWithTag("HP3");
        deathLayer = GameObject.FindGameObjectWithTag("Death");
        respawnPoint = GameObject.FindGameObjectWithTag("RespawnPoint");
    }

    void Update()
    {
        if (!isPlayerInScene && health != 0)
        {
            Invoke("reActivate", 3f);
        }

    }

    void FixedUpdate()  
    {
        
        Patrol(); 

    }

    bool Grounded()
    {
        float laserLength = 0.25f;
        Vector2 startPosition = (Vector2) transform.position - new Vector2(0f, (boxcol2d.bounds.extents.y) + 0.05f);
        int layerMask = LayerMask.GetMask("Player");
        RaycastHit2D hit = Physics2D.Raycast(startPosition, Vector2.down, laserLength, layerMask);
        
        return hit.collider != null;
    }

    void Patrol()
    {
        Debug.Log("patrol");

        Vector2 startPosition = (Vector2) transform.position;
        int layerMask = LayerMask.GetMask("HiddenObj");

        if (dir)
        {
            // left raycast
            RaycastHit2D hit = Physics2D.Raycast(startPosition, Vector2.left, laserLength, layerMask);

            if (hit.collider == null)
            {
                transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0f, 0f);
            }
            
            if (hit.collider != null)
            {
                Debug.Log("hit");
                spriteRenderer.flipX = true;                
                dir = false;
            }
        }

        if (!dir)
        {
            // right raycast
            RaycastHit2D hit = Physics2D.Raycast(startPosition, Vector2.right, laserLength, layerMask);

            if (hit.collider == null)
            {
                transform.position += new Vector3(movementSpeed * Time.deltaTime, 0f, 0f);
            }

            if (hit.collider != null)
            {
                Debug.Log("hit");
                spriteRenderer.flipX = false;                
                dir = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.collider.tag == "Player" && player.GetComponent<DeathController>().health == 3 && player.GetComponent<DeathController>().health != 2 && player.GetComponent<DeathController>().health != 1 && player.GetComponent<DeathController>().health != 0)
        {
            player.GetComponent<DeathController>().health -= 1; 
            isPlayerInScene = false;
            Debug.Log(player.GetComponent<DeathController>().health);

            Heart3.GetComponent<Image>().color = Color.black;
            player.transform.position = respawnPoint.transform.position;
            isPlayerInScene = true;

            return;
            
        }
        if (col.collider.tag == "Player" && player.GetComponent<DeathController>().health == 2 && player.GetComponent<DeathController>().health != 3 && player.GetComponent<DeathController>().health != 1 && player.GetComponent<DeathController>().health != 0)
        {
            player.GetComponent<DeathController>().health -= 1; 
            isPlayerInScene = false;
            Debug.Log(player.GetComponent<DeathController>().health);
            Heart2.GetComponent<Image>().color = Color.black;
            player.transform.position = respawnPoint.transform.position;
            isPlayerInScene = true;

            return;
            
        }
        if (col.collider.tag == "Player" && player.GetComponent<DeathController>().health == 1 && player.GetComponent<DeathController>().health != 3 && player.GetComponent<DeathController>().health != 2 && player.GetComponent<DeathController>().health != 0)
        {
            player.GetComponent<DeathController>().health -= 1; 
            isPlayerInScene = false;
            Debug.Log(player.GetComponent<DeathController>().health);
            Heart1.GetComponent<Image>().color = Color.black;
            player.transform.position = respawnPoint.transform.position;
            player.SetActive(false);
            SceneManager.LoadScene(gameOver);
            return;
            
        }
    }

    void reActivate()
    {
        player.SetActive(true);       
        
        
    }
    
}
