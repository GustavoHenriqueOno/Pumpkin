using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float speed;
    [SerializeField] float distance;

    void Start()
    {
        
    }

    void Update()
    {        
        Vector3 target_position = player.position;
        target_position.y = transform.position.y;
        target_position.z = -distance;

        transform.position = Vector3.Lerp(transform.position, target_position, speed *Time.deltaTime);
    }
}
