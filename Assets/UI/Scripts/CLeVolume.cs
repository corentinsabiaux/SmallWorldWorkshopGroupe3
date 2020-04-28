using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class CLeVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public void SetLevel(Slider slider)
    {
        if (slider.value > 0)
        {
            mixer.SetFloat("GamVol", Mathf.Log10(slider.value) * 20);
        }
        else
        {
            mixer.SetFloat("GamVol", -80);
        }
    }
    public void shutVolume(Slider slider)
    {
        float value = 1;
        if (slider.value != 0)
        {
            value = slider.value;
            slider.value = 0;
        }
        else
        {
            slider.value = value;
        }
    }
}

