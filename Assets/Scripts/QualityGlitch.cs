using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class QualityGlitch : MonoBehaviour
{

    public GameObject glitchEffect;

    public CRT crt;
    Bloom bloomLayer = null;
    void Start()
    {
        PostProcessVolume volume = gameObject.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out bloomLayer);

        
        if(QualitySettings.GetQualityLevel() == 5){
            glitchEffect.SetActive(true);
            bloomLayer.intensity.value = 0.64f;
            bloomLayer.threshold.value = 0.59f;
        }else{
            glitchEffect.SetActive(false);
            bloomLayer.intensity.value = 0.64f;
            bloomLayer.threshold.value = 0.59f;
        }

        if(QualitySettings.GetQualityLevel() == 0){
            crt.enabled = false;
            volume.enabled = false;
        }else if(QualitySettings.GetQualityLevel() == 1){
            crt.enabled = false;
            volume.enabled = true;
        }else{
            crt.enabled = true;
            volume.enabled = true;
        }
    }
}
