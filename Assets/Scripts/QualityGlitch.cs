using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class QualityGlitch : MonoBehaviour
{

    public GameObject glitchEffect;
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
    }
}
