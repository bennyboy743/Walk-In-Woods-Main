using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerAnim : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator _animator;
    const float acclerationSpeed = 0.015f;
    

    float speed;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            speed += acclerationSpeed;
        else
            speed -= acclerationSpeed;

        if (Input.GetKey(KeyCode.S))
        {

        }

        


        speed = Mathf.Clamp(speed, 0, 1); 
        
        
        _animator.SetFloat("speed", speed);
        
    }


    
  
}
