using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] music;
    public AudioSource BackGroundMusic;
    public AudioSource BackGroundMusic1;
    public AudioSource soundeffect;
    
    

    void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
        
    }
    private void Start()
    {
        PlayBackgorund(0);
    }
    public void PlayBackgorund(int idx)
    {
        if (idx == 0)
        {
            BackGroundMusic = gameObject.AddComponent<AudioSource>();
            BackGroundMusic.clip = music[0];
            BackGroundMusic.loop = true;
            BackGroundMusic.volume = 0.5f;
            BackGroundMusic.Play();
        }
        if (idx == 1)
        {
            BackGroundMusic1 = gameObject.AddComponent<AudioSource>();
            BackGroundMusic1.clip = music[1];
            BackGroundMusic1.Play();
        }
    }

    public void StopPlayingBackground(int idx)
    {
        if(idx == 0)
        {
            BackGroundMusic.Stop(); 
        }
        if (idx == 1)
        {
            if (BackGroundMusic1 != null)
            {
                BackGroundMusic1.Stop();
            }
        }
        
    }

    public void PlaySoundeffect(int idx)
    {
        
        soundeffect = gameObject.AddComponent<AudioSource>();
        soundeffect.clip = music[idx];
        if (music[idx].name == "SFX_UIConfirm")
        {
            soundeffect.volume = 0.3f;
        }
       
       
        soundeffect.Play();
    }
    public void StopPlaySoundeffect()
    {
        if (soundeffect != null)
        {
            soundeffect.Stop();
        }
    }

    
    
}
