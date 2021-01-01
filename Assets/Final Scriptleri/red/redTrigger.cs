using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class redTrigger : MonoBehaviour
{
    Text redtext;
    
    void Start()
    {
        redtext = GameObject.FindGameObjectWithTag("enterred").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (redtext.text == "Girmek için Enter tuşuna tıkla!" && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene("02");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "redcol")
        {
           redtext.text = "Girmek için Enter tuşuna tıkla!";
        }
        
    }

}
