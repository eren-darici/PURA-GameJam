using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load2 : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("02");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
