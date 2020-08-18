using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ActiveTv : MonoBehaviour
{
    private IEnumerator coroutine;
    public AudioClip voiceClip;
    private AudioSource audio_voice;
    public Text dielog;
    void Start()
    {
        coroutine = WaitAndPrint(15);
        StartCoroutine(coroutine);
        StartCoroutine(PlayVoice());
        
    }

    // Update is called once per frame
    void Update()
    {
        
      
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
       var vp = GetComponent<UnityEngine.Video.VideoPlayer>();
       
       yield return new WaitForSeconds(waitTime);
       vp.Stop();
    }

    private IEnumerator PlayVoice()
    {
        yield return new WaitForSeconds(10);
        audio_voice = GetComponent<AudioSource>();
        audio_voice.clip = voiceClip;
        audio_voice.Play();
    }
}
