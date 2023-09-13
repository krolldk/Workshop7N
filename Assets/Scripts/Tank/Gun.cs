using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float GunSpeed;
    public Steering Steer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Steer.ControllerMode == Steering.Mode.Player)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Rotate(GunSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Rotate(-GunSpeed * Time.deltaTime, 0, 0);
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }
    }

    private void Fire()
    {
        Steer.Recoil(transform.TransformDirection(Vector3.down));
    }
}
