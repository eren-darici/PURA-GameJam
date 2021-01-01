using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class endofthegame : MonoBehaviour
{
    Text endText;
    public int dialogCounter = 0;
    public bool isCol = false;
    public SoundManager soundManager;

    private string dialogOne = "!!!...";
    private string dialogTwo = "Gelmişsin...";
    private string dialogThree = "Evine hoşgeldin hayatım.";

    void Start()
    {
        endText = GameObject.FindGameObjectWithTag("endofgame").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) && isCol)
        {
            dialogCounter += 1;
            switch (dialogCounter)
            {
                case 1:
                endText.text = dialogOne;
                break;

                case 2:
                endText.text = dialogTwo;
                break;

                case 3:
                endText.text = dialogThree;
                break;

                case 4:
                SceneManager.LoadScene("finalkiss");
                break;

            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            isCol = true;
            soundManager.Stop();
            col.GetComponent<PlayerMovement>().enabled = false;
            col.GetComponent<Animator>().SetBool("isRunning", false);
            endText.text = dialogOne;
            dialogCounter++;

        }
       
    }
}
