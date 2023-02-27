using System;
using UnityEngine;

namespace MouseMountain
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource Ambient;
        public AudioSource FX;
        public AudioClip test;
// ENCAPSULATION
        public static AudioManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
            DontDestroyOnLoad(this);
        }

        public void PlayFX()
        {
            FX.clip = test;
            FX.Play();
        }

        public void StopFX()
        {
            FX.Stop();
        }

        public void PlayAmbient(AudioClip _ambientLoop)
        {
            Ambient.clip = _ambientLoop;
            Ambient.Play();
        }
    }
}