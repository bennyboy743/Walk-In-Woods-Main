using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFog : MonoBehaviour
{
    public bool fogActive;
    public float fogDensity;
    public Light sun;
    Color lerpedColor = Color.black;
    void Start()
    {
        InitFog();
    }

    void InitFog()
    {
        lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
        RenderSettings.fog = false;
        RenderSettings.fogMode = FogMode.Exponential;
        sun.GetComponent<Light>().color = lerpedColor;
        sun.GetComponent<Light>().intensity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFog();
    }

    void UpdateFog()
    {
    {
        RenderSettings.fog = fogActive;
        RenderSettings.fogDensity = fogDensity;
    }
}
