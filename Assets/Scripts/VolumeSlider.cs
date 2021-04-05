using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider musicSlider;
    public Slider gameSlider;
    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume")) { 
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            musicSlider.value = 1;
        }
        if (PlayerPrefs.HasKey("GameVolume"))
        {
            gameSlider.value = PlayerPrefs.GetFloat("GameVolume");
        }
        else
        {
            gameSlider.value = 1;
        }
    }
    private void Update()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("GameVolume", gameSlider.value);
        
    }
}
