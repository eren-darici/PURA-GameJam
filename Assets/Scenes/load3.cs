using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load3 : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("03");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
