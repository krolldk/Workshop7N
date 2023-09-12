using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float RotationSpeedYAxis = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))  //if RMB is held down. 0==LMB, 2 ==MMB, 1 == RMB
        {
            float dx = Input.GetAxis("Mouse X"); //Movement of mouse in x-axis direction
            float rotY = dx * Time.deltaTime * RotationSpeedYAxis;
            Vector3 eulers = transform.eulerAngles;
            eulers.y += rotY;
            transform.eulerAngles = eulers;

        }
    }
}
