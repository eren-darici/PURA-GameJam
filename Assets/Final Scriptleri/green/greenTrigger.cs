using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class greenTrigger : MonoBehaviour
{
    Text greentext;
    
    void Start()
    {
        greentext = GameObject.FindGameObjectWithTag("entergreen").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (greentext.text == "Girmek için Enter tuşuna tıkla!" && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene("01");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "greencol")
        {
           greentext.text = "Girmek için Enter tuşuna tıkla!";
        }
        
    }

}
