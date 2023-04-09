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
    [SerializeField] private float followSpeed;
    [SerializeField] private bool isXLocked;
    [SerializeField] private bool isYLocked;
    private void Update()
    {
        // transform.position = new Vector3((player.position.x + offsetX), (player.position.y + offsetY), (transform.position.z + offsetZ));

        // set initial camrea settings
        isYLocked =  true;
        followSpeed = 4;

        // camera follow smoothing
        float xTarget = player.position.x + offsetX;
        float yTarget = player.position.y + offsetY;

        float xNew = transform.position.x;
        // code for locking camera axis
        if (!isXLocked) {
            xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
        }

        float yNew = transform.position.y;
        if (!isYLocked) {
            yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);
        }

        transform.position = new Vector3(xNew, yNew, transform.position.z);
    }
}
