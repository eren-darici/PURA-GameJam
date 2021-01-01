using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DeathController : MonoBehaviour
{
    GameObject Heart1;
    GameObject Heart2;
    GameObject Heart3;
    GameObject respawnPoint;
    GameObject deathLayer;
    public bool isPlayerInScene = true;
    public int health = 3;
    public string gameOver;

    

    void Start() //liste kullan!
    {
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Death" && health == 3 && health != 2 && health != 1 && health != 0)
        {
            health -= 1; 
            isPlayerInScene = false;
            Debug.Log(health);
            Heart3.GetComponent<Image>().color = Color.black;
            gameObject.transform.position = respawnPoint.transform.position;
            isPlayerInScene = true;

            return;
            
        }
        if (col.tag == "Death" && health == 2 && health != 3 && health != 1 && health != 0)
        {
            health -= 1; 
            isPlayerInScene = false;
            Debug.Log(health);
            Heart2.GetComponent<Image>().color = Color.black;
            gameObject.transform.position = respawnPoint.transform.position;
            isPlayerInScene = true;

            return;
            
        }
        if (col.tag == "Death" && health == 1 && health != 3 && health != 2 && health != 0)
        {
            health -= 1; 
            isPlayerInScene = false;
            Debug.Log(health);
            SceneManager.LoadScene(gameOver);
            Heart1.GetComponent<Image>().color = Color.black;
            gameObject.transform.position = respawnPoint.transform.position;
            gameObject.SetActive(false);
            return;
            
        }
        
    }

    void reActivate()
    {
        gameObject.SetActive(true);       
        
        
    }
}
