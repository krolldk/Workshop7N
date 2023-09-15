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
        Recoil();
        CheckHit();
    }

    public void Recoil()
    {
        StartCoroutine(DoRecoil());
    }

    private IEnumerator DoRecoil()
    {
        Vector3 position = transform.localPosition;
        Vector3 direction =transform.parent.InverseTransformDirection(transform.up * -1);
        transform.localPosition += direction * 0.15f;
        while (Vector3.Distance(transform.localPosition, position) > 0.02f)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, position, 10 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        transform.localPosition = position;
    }

    void CheckHit()
    {
        Vector3 direction = transform.up;
        Ray charles = new Ray(transform.position, direction);
        RaycastHit hit;
        if(Physics.Raycast(charles, out hit))
        {
            //We hit something
            Collider col = hit.collider;
            Target t = col.GetComponent<Target>();
            if(t != null)
            {
                t.OnHit(hit.point, transform.position); 
            }
         }

    }

}
