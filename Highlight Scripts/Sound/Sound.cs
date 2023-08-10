using System;
using UnityEngine;
using UnityEngine.Audio;

namespace DefaultNamespace
{
    [Serializable] public class Sound
    {
        public SoundManager.SoundName soundName;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume;
        public bool loop;
        [Range(-3f,3f)]public float pitch;
        [Range(0f,3f)] public float spatialBlend;
        public AudioRolloffMode rolloffMode;
        public float minDistance;
        public float maxDistance;
        [HideInInspector] public AudioSource audioSource;
    }
}