using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class purpleTrigger : MonoBehaviour
{
    Text purpletext;
    
    void Start()
    {
        purpletext = GameObject.FindGameObjectWithTag("enterpurple").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (purpletext.text == "Girmek için Enter tuşuna tıkla!" && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene("03");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "purplecol")
        {
           purpletext.text = "Girmek için Enter tuşuna tıkla!";
        }
        
    }

}
