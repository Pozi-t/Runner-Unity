using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - player.position;
        if (PlayerPrefs.GetString("Music") == "Yes")
            GetComponent<AudioSource>().Play();
        else GetComponent<AudioSource>().Stop();
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);

    }

    void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(player.position.x, transform.position.y, offset.z + player.position.z);
        //Vector3 newPosition = new Vector3(player.position.x, transform.position.y, offset.z + player.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, 10.0f * Time.fixedDeltaTime);
        
    }
    //private void Update()
    //{
    //    //Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);
    //    Vector3 newPosition = new Vector3(player.position.x, transform.position.y, offset.z + player.position.z);
    //    transform.position = newPosition;
    //}
}
