using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class CLeVolume : MonoBehaviour
{
    public GameObject ButtonSoundLogoOn;
    public GameObject ButtonSoundLogoOff;

    public float value;
    //Change le volume via un slider

    public void Update()
    {
    }
    public void SetLevel(Slider slider)
    {
        //Check si la valeur du slider est supérieure à 0
        if (slider.value > 0)
        {
            //ajuste le volume
            GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().volume = slider.value;
            value = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().volume;
        }
    }
    //coupe le volume quand le bouton est cliqué
    public void shutVolume(Slider slider)
    {
        ButtonSoundLogoOn.SetActive(false);
        ButtonSoundLogoOff.SetActive(true);
        //Check si le volume est différent de 0
        if (slider.value != 0)
        {
            //coupe le volume et stcke le niveau de volume precedent
            slider.value = 0;
            GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().volume = 0;
        }
    }

    public void onVolume(Slider slider)
    {
        ButtonSoundLogoOff.SetActive(false);
        ButtonSoundLogoOn.SetActive(true);
        //Check si le volume est différent de 0
        if (slider.value != 1)
        {
            //relance le volume et le met à sa derniere valeur stockée
            slider.value = value;
            GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().volume = value;
        }
    }
}

