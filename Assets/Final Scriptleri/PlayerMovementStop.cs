using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementStop : MonoBehaviour
{
    public GameObject player;
    public GameObject sahneTrigger;
    public GameObject psikologText;
    public BoxCollider2D yenge;
    public bool isMoveBlock;
    public bool isYengeBlock;
    public int yengeCounter = 0;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMovement>().enabled = false;
        sahneTrigger = GameObject.FindGameObjectWithTag("sahnetrigger");
        psikologText = GameObject.FindGameObjectWithTag("PsikologText");
        yenge = GameObject.FindGameObjectWithTag("yengepembe").GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {

        if (isMoveBlock && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            psikologText.SetActive(false);
        }

        if (isYengeBlock && yengeCounter != 3 && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            yengeCounter++;
        }

        if (yengeCounter == 4)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            yenge.enabled = false;
            
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "sahneyasagi")
         {
            col.GetComponent<BoxCollider2D>().enabled = true;
            sahneTrigger.GetComponent<BoxCollider2D>().enabled = false;
         }
        if (col.tag == "movblock" && !Input.GetKeyDown(KeyCode.Space))
        {
            isMoveBlock = true;
        }

        if (col.tag == "movblock" && Input.GetKeyDown(KeyCode.Space))
        {
            isMoveBlock = false;
        }

        if (col.tag == "yengepembe")
        {
            isYengeBlock = true;
            yengeCounter++;
        }
    }

}
