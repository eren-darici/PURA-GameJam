using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class endofone : MonoBehaviour
{
    Text endText;
    public int dialogCounter = 0;
    public bool isCol = false;
    public SoundManager soundManager;

    private string dialogOne = "Geldin demek? Ben şimdiye korkup kaçtın sanmıştım haha. Umarım yanıma boş yere gelmemişsindir. \nTerkedilme korkun yüzünden buralara kadar sızabiliecek fırsatı buldum. Tabiki öfke ve kıskançlık da benzer sebeplerle her yeri sardı.";
    private string dialogTwo = "Bütün bunlar bir yana, çabalarını gördüm; içinde bir şeyler sonunda değişmeye başlamış gibi gözüküyor.\nPekala madem buraya kadar geldin. Tek başına gitmen tehlikeli. \nSana yardım edip yolunu aydınlatacağım. Ehe, kesinlikle onlardan korktuğum için değil...";


    

    void Start()
    {
        endText = GameObject.FindGameObjectWithTag("level1dialog").GetComponent<Text>();
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
                SceneManager.LoadScene("Ev01");
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
