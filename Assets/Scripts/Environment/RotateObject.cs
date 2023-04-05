using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    //
    [SerializeField] private float speed = 2f;
    
    // Update is called once per frame
    private void Update()
    {
        // Time.deltaTime makes the speed of rotation framerate independent
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
