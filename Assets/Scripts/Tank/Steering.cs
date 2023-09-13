using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
    public enum Mode { NPC, Player }
    public Mode ControllerMode = Mode.NPC;

    public float MaxSpeed = 5;
    public float Accelleration = 1;
    public float TurnSpeed = 30;
    private float CurrentSpeed;

    // Update is called once per frame
    void Update()
    {
        if(ControllerMode == Mode.NPC)
        {
            NPCControllerUpdate();
        } else
        {
            PlayerControllerUpdate();
        }
        Move();
    }

    void NPCControllerUpdate()
    {

    }

    void PlayerControllerUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GoForward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            GoBackward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            TurnLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            TurnRight();
        }
    }

    void GoForward()
    {
        CurrentSpeed += Accelleration * Time.deltaTime;
    }
    void GoBackward()
    {
        CurrentSpeed -= Accelleration * Time.deltaTime;
    }

    void TurnLeft()
    {
        transform.Rotate(0, TurnSpeed * Time.deltaTime, 0);
    }
    void TurnRight()
    {
        transform.Rotate(0, -TurnSpeed * Time.deltaTime, 0);
    }


    private void Move()
    {
        transform.Translate(0, 0, CurrentSpeed * Time.deltaTime);
        if (CurrentSpeed > 0)
        {
            CurrentSpeed -= Accelleration * 0.5f * Time.deltaTime;
        }
        if (CurrentSpeed < 0)
        {
            CurrentSpeed += Accelleration * 0.5f * Time.deltaTime;
        }
    }

    public void Recoil(Vector3 direction)
    {
        StartCoroutine(DoRecoil(direction));
    }

    private IEnumerator DoRecoil(Vector3 direction)
    {
        Vector3 position = transform.position;
        transform.position += direction*0.25f;
        while (Vector3.Distance(transform.position, position) > 0.02f)
        {
            transform.position = Vector3.Lerp(transform.position, position, 10*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
