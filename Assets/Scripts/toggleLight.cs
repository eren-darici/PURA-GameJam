using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleLight : MonoBehaviour
{
    public GameObject[] flashlight;
    public bool isFlaslightOn = false;

    void Start()
    {
        flashlight = GameObject.FindGameObjectsWithTag("Light");
    }

    void Update()
    {
        foreach (GameObject fl in flashlight)
        {
            fl.SetActive(isFlaslightOn);
        }

        toggleFlash();

        

    }

    void toggleFlash()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFlaslightOn = !isFlaslightOn;
        }
    }
}
