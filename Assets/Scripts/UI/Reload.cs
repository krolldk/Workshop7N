using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    Image Background;

    public float ReloadLeft
    {
        set
        {
            value = Mathf.Clamp01(value);
            Background.fillAmount = 1 - value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Background = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
