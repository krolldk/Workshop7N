using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float TurnSpeed = 20f;
    public Steering Parent;

    private void Start()
    {
        //Start is called once, just before Start is called first time
    }

    // Update is called once per frame
    void Update()
    {
        if(Parent.ControllerMode == Steering.Mode.Player)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, -TurnSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, TurnSpeed * Time.deltaTime, 0);
            }
        }
    }
}
