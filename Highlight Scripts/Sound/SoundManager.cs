using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using DefaultNamespace;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private Sound[] sounds;
    
    public enum SoundName
    { 
        PlatformBreak,
        PlayerAttack,
    }
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(this); 
            return;
        }
    }
    
    public void Play(SoundName name)
    {
        //1. Get sound from sounds array
        Sound sound = GetSound(name);
        if (sound.audioSource == null)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.loop = sound.loop;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.spatialBlend = sound.spatialBlend;
            sound.audioSource.minDistance = sound.minDistance;
            sound.audioSource.maxDistance = sound.maxDistance;
            sound.audioSource.rolloffMode = sound.rolloffMode;
        }
        //2. Play
        sound.audioSource.Play();
    }

    private Sound GetSound(SoundName name)
    {
        return Array.Find(sounds, s => s.soundName == name);
    }
}
