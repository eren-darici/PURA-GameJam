using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class greenTrigOff : MonoBehaviour
{
    Text greentext;
    
    void Start()
    {
        greentext = GameObject.FindGameObjectWithTag("entergreen").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
           greentext.text = "";
        }
       
    }

}
