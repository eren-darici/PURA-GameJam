using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class arrowScript : MonoBehaviour
{
    GameObject player;
    
    GameObject Heart1;
    GameObject Heart2;
    GameObject Heart3;
    GameObject respawnPoint;
    GameObject deathLayer;
    public bool isPlayerInScene = true;



    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameObject.SetActive(false);
        Heart1 = GameObject.FindGameObjectWithTag("HP1");
        Heart2 = GameObject.FindGameObjectWithTag("HP2");
        Heart3 = GameObject.FindGameObjectWithTag("HP3");
        deathLayer = GameObject.FindGameObjectWithTag("Death");
        respawnPoint = GameObject.FindGameObjectWithTag("RespawnPoint");

    }

    void Update()
    {
        if (!isPlayerInScene && player.GetComponent<DeathController>().health != 0)
        {
            Invoke("reActivate", 3f);
        }

        if (!isPlayerInScene && player.GetComponent<DeathController>().health == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - -1);
        }
        
    }
    
    void OnEnable()
    {

    }

    void OnDisable()
    {

    }

    void Reset()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
        {
           gameObject.SetActive(false);
        }
        if (col.collider.tag == "Destroyable")
        {
           gameObject.SetActive(false);
        }
        if (col.collider.tag == "HiddenObj")
        {
           gameObject.SetActive(false);
        }
        
        if (col.collider.tag == "Player")
        {
            gameObject.SetActive(false);
            
        }

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
            return;
            
        }
    }

    void reActivate()
    {
        player.SetActive(true);       
        
        
    }
}
