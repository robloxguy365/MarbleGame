using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    private static MusicPlayer musicInstance;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (musicInstance == null)
        {
            _audioSource = GetComponent<AudioSource>();
            musicInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (PlayerPrefs.HasKey("MusicVolume")) { 
            if(_audioSource.volume != PlayerPrefs.GetFloat("MusicVolume"))
            {
                _audioSource.volume = PlayerPrefs.GetFloat("MusicVolume");
            }
        }
        else
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
            PlayerPrefs.SetFloat("GameVolume", 1);
        }
    }
    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }
    
    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
