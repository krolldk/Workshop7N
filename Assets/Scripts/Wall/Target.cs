using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void OnHit(Vector3 hitPoint, Vector3 origin)
    {
        //I was hit at hitPoint, from position origin
        GetComponent<Rigidbody>().AddExplosionForce(2000, hitPoint, 10);
        
    }
}
