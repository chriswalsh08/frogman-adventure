using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // initialize variables
    [SerializeField] private Transform player;

    [SerializeField] private float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;
    private void Update()
    {
        transform.position = new Vector3((player.position.x + offsetX), (player.position.y + offsetY), (transform.position.z + offsetZ));
    }
}
