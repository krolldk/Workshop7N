using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steering : MonoBehaviour
{
    public enum Mode { NPC, Player }
    public Mode ControllerMode = Mode.NPC;

    public float MaxSpeed = 5;
    public float Accelleration = 1;
    //privates do not how up in editor
    private float CurrentSpeed;
    //..unless tagged with SerializeField
    [SerializeField] private float TurnSpeed = 30;
    [SerializeField] Color myColor;
    [SerializeField] private Material myMaterial;


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

    private void OnValidate()
    {
        if(myMaterial == null)
        {
            myMaterial = GetComponent<Renderer>().material;
        }

        if(myMaterial != null)
        {
            myMaterial.color = myColor;
        }
        if(Accelleration <0)
        {
            //We do not allow designers to set acc to less than zero
            Accelleration = 0;
        }
    }

}
