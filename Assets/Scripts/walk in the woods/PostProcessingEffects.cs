using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingEffects : MonoBehaviour
{
    public PostProcessVolume volume;

    private Bloom _Bloom;
    private Vignette _Vignette;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out _Bloom);
        volume.profile.TryGetSettings(out _Vignette);

        _Bloom.intensity.value = 10;
        _Vignette.intensity.value = 100;

    }

    // Update is called once per frame
    void Update()
    {
        _Bloom.intensity.value = Mathf.Lerp(_Bloom.intensity.value, 100, .10f * Time.deltaTime);
        _Vignette.intensity.value = Mathf.Lerp(_Vignette.intensity.value, 5, .10f * Time.deltaTime);
    }
}
