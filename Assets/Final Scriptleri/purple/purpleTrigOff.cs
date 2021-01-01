using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class purpleTrigOff : MonoBehaviour
{
    Text purpletext;
    
    void Start()
    {
        purpletext = GameObject.FindGameObjectWithTag("enterpurple").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
           purpletext.text = "";
        }
       
    }

}
