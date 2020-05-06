using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class CLeVolume : MonoBehaviour
{
    
    public AudioMixer mixer;
    //Change le volume via un slider
    public void SetLevel(Slider slider)
    {
        //Check si la valeur du slider est supérieure à 0
        if (slider.value > 0)
        {
            //ajuste le volume
            mixer.SetFloat("GamVol", Mathf.Log10(slider.value) * 80);
        }
        else
        {
            //coupe le volume
            mixer.SetFloat("GamVol", -80);
        }
    }
    //coupe le volume quand le bouton est cliqué
    public void shutVolume(Slider slider)
    {
        float value = 1;
        //Check si le volume est différent de 0
        if (slider.value != 0)
        {
            //coupe le volume et stcke le niveau de volume precedent
            value = slider.value;
            slider.value = 0;
        }
        else
        {
            //relance le volume et le met à sa derniere valeur stockée
            slider.value = value;
        }
    }
}

