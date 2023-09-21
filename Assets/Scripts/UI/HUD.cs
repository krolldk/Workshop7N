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
        Channel<Gun.FireSignal>.Subscribe(OnFireSignal);
    }

    private void OnFireSignal(Gun.FireSignal firing)
    {
        //Gun was fired. Do UI update and gamelogic
        reload.ReloadLeft = 1f;
    }

    private void Update()
    {
        if(reload.ReloadLeft > 0)
        {
            reload.ReloadLeft -= Time.deltaTime;
        }
    }

}
