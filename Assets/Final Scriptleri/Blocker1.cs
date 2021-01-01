using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker1 : MonoBehaviour
{
    public GameObject sahneTrigger;
    public GameObject sahneYasak1;

    

    void Start()
    {
        sahneTrigger = GameObject.FindGameObjectWithTag("sahnetrigger");    
        sahneYasak1 = GameObject.FindGameObjectWithTag("sahneyasagi");    
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("col");
        if (col.tag == "sahnetrigger")
         {
            col.GetComponent<BoxCollider2D>().enabled = false;
            sahneYasak1.GetComponent<BoxCollider2D>().enabled = true;
         }
    }
}
