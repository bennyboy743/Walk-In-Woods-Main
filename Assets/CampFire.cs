using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fire;
    public GameObject firePartical;
    private Light fireFlame;
    private ParticleSystem fireP;

    void Start()
    {

        fireFlame = fire.GetComponent<Light>();
        fireP = firePartical.GetComponent<ParticleSystem>();

        fireFlame.enabled = true;
       




    }

    // Update is called once per frame
    void Update()
    {
        fireFlame.intensity = Random.Range(3.8f,9f);
        fireP.Play();
    }
}
