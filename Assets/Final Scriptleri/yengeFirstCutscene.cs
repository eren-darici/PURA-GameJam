using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yengeFirstCutscene : MonoBehaviour
{
    public GameObject player;
    public GameObject yengeText;
    Animator animator;
    public SoundManager soundManager;

    public int dialogCounter = 0;
    public bool isCol = false;

    private string dialogOne = "Selam. Neden bana öyle bakıyorsun? Korkmuş gözüküyorsun. Ah, galiba anladım. Beni sevgilinle karıştırıyorsun. Ben senin sevgilin Sevda değil sadece senin sevgi duygunum.";

    private string dialogTwo = "Beni onun kılığında görmenin nedeni ona duyduğun bu yoğun sevgi. Şimdi beni iyi dinle buralarda bazı benim gibi duygular var fakat onlar benim gibi değil. Çok daha";
    private string dialogThree = "... kötüler.  Bazılarının senin hatıra yüklü eşyalarının içine girip orada yuva yaptığını gördüm. Onları gidip durdurmalısın yoksa bütün duyguların ve tabii ki senin için her şey geç olabilir. Sevda'yı hayal kırıklığına uğratma. İyi şanslar.";

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        yengeText = GameObject.FindGameObjectWithTag("yengetext");
        yengeText.SetActive(false);
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.KeypadEnter) && isCol)
        {
            dialogCounter++;

            switch (dialogCounter)
            {
                case 2:
                yengeText.GetComponent<Text>().text = dialogTwo;
                break;

                case 3:
                yengeText.GetComponent<Text>().text = dialogThree;
                break;

                case 4:
                isCol = false;
                player.GetComponent<PlayerMovement>().enabled = true;
                yengeText.SetActive(false);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                break;

            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            isCol = true;
            Debug.Log("paralyzed");
            player.GetComponent<PlayerMovement>().enabled = false;
            animator.SetBool("isRunning", false);
            soundManager.Stop();
            yengeText.SetActive(true);
            yengeText.GetComponent<Text>().text = dialogOne;
            dialogCounter++;
        }

    }
}
