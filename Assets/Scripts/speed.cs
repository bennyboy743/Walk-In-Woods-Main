using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
    // Start is called before the first frame update
    const float acceleration = 0.0099f;
    

    float speedy;
    
    public Animator ani;
    
   // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            speedy += acceleration;
        else
            speedy -= acceleration;

        speedy = Mathf.Clamp(speedy, 0, 1);

        
        ani.SetFloat("speed", speedy);
    }
}
