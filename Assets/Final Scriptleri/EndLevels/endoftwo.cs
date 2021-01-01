using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class endoftwo : MonoBehaviour
{
    Text endText;
    public int dialogCounter = 0;
    public bool isCol = false;
    public SoundManager soundManager;
    

    private string dialogOne = "Grrr Öfkenin karşısında durmaya nasıl cüret edersin?! Senin şimdiye kadar Öfke'nin esiri olman gerekirdi! \nÜstelik korkuyla ortak bir yola girmiş gözüküyorsun. Bunların hepsi Öfke'yi daha da kızdırıyor! O kıza yaşattıkların... \nSuçu bana atmaya kalkman... \nÖfke böyle değildi!";
    private string dialogTwo = "Öfke eskiden bir ihtiyaçtı! \nŞimdi ise Öfke sadece basit bir bahane! Neden bütün bunları yapıyorsun? Buraya Öfke'yle anlaşmaya mı geldin? \nAslında.. \nBuraya gelebilmenin tek yolu Öfke'yi bir motivasyon kaynağı olarak kullanmaktı.";
    private string dialogThree = "Öfke şaşırdı... \nO halde tamam. \nÖfke sende bir ışık görüyor. \nAma şimdiden söyleyeyim Öfke artık senin bir oyuncağın değil!";

    void Start()
    {
        endText = GameObject.FindGameObjectWithTag("level2dialog").GetComponent<Text>();
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
                SceneManager.LoadScene("Ev02");
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
