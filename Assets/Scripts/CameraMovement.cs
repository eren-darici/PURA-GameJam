using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Transform target;
    public float xOffset;
    public float yOffset;
    [SerializeField] private AudioSource audioSource;

    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        transform.position = new Vector3(target.position.x + xOffset, target.position.y + yOffset, transform.position.z);
    }
}
