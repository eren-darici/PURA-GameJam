using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerHead : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (col.tag == "Destroyable")
        {
            col.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (col.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
