using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{   
    public GameObject arrowPrefab;
    public bool isArrowShooting;
    public GameObject firePoint;
    public float everySec;
    public float arrowSpeed;
    public AudioSource audioSource;
    public GameObject[] arrowList;
    private int index;

    
    

    void Start()
    {
        StartCoroutine(shootArrows());
    }

    public IEnumerator shootArrows() {
    while(true) {
        yield return new WaitForSeconds (everySec);
        // Instantiate (arrowPrefab, firePoint.transform.position, firePoint.transform.rotation).GetComponent<Rigidbody2D>().velocity = new Vector2(-arrowSpeed, 0f);
        var currentArrow = getNextArrow();
        currentArrow.SetActive(true);
        currentArrow.transform.position = firePoint.transform.position;
        currentArrow.transform.rotation = firePoint.transform.rotation;
        currentArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(-arrowSpeed, 0f);
        audioSource.Play();

        isArrowShooting = true;
        yield return new WaitForSeconds (everySec);
        isArrowShooting = false;
    }
}

    GameObject getNextArrow()
    {
        if (arrowList.Length <= index)
        {
            index = 0;
        }
        return arrowList[index];
    }

   
}
