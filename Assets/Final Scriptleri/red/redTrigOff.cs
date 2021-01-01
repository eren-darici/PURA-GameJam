using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class redTrigOff : MonoBehaviour
{
    Text redtext;
    
    void Start()
    {
        redtext = GameObject.FindGameObjectWithTag("enterred").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
           redtext.text = "";
        }
       
    }

}
