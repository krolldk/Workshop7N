using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public Reload reload;

    // Start is called before the first frame update
    void Start()
    {
        reload.ReloadLeft = 0;        
    }

}
