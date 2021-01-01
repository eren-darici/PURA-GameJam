using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load1 : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("01");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
