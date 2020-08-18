using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Light flashLight;
    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        InitFlash();
    }

    void InitFlash()
    {
        isActive = true;
        flashLight = GetComponent<Light>();
        flashLight.intensity = 3.5f;
        
     }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            EnableFlashLight();
        }
    }

    void EnableFlashLight()
    {
        //turns the light on and off with the key f
        isActive = !isActive;
        flashLight.enabled = isActive;
    }
}
