using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class endofthree : MonoBehaviour
{
    Text endText;
    public int dialogCounter = 0;
    public bool isCol = false;
    public SoundManager soundManager;

    private string dialogOne = "Sonunda! \nNeyle uğraşıyordun şimdiye kadar ha? Aaa şimdi görebiliyorum korku ve öfkeyi kendi tarafına çekmişsin, peki ya bana gelmek daha yeni mi aklına geliyor?? \nAh, neler diyorum böyle. Neden? Neden bu hale geldim? ";
    private string dialogTwo = "İnan bana sürekli kendime bu soruyu soruyorum. Sırf senin kendine olan güvensizliğin yüzünden burada acı çekiyoruz. \nBiz senin zihnin dışında varolmamalıyız. Bizi buraya sürükleyen şey bir döngü. \nKıskançlığın korkuyu korkunun da öfkeyi beslediği sonsuza dek devam eden bir döngü.";
    private string dialogThree = "Az önceye kadar kabul etmek istemesem de sen bu döngüyü kırdın. \nÇoktan öfkenin ve korkunun artık senin hayatında bir engel değil itici bir güç haline geldiğini görebiliyorum. \nFakat içinde hala bir şeyler yanlış. Mesele kız değil. Bu senin içindeki bir şey.";
    private string dialogFour = "Neden kendine güvenmiyorsun? \nKendini değersiz mi hissediyorsun? Sakin ol. Yavaş yavaş geçecek. \nSonuçta buraya kadar geldin ha. Kız sana güveniyor. \nSen de ona güven. Daha da önemlisi... Kendine güven.";

    void Start()
    {
        endText = GameObject.FindGameObjectWithTag("level3dialog").GetComponent<Text>();
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
                endText.text = dialogFour;
                break;

                case 5:
                SceneManager.LoadScene("final");
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
