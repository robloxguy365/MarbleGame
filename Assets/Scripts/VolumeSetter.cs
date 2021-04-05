using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSetter : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("MusicVolume");
    }
}
