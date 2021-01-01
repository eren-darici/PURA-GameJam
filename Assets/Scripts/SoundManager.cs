using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource FXSource;
    public AudioClip[] clips;
    private Soundtype soundType;


    void Awake()
    {
        instance = this;    
        soundType = new Soundtype(clips);
    }

    public void playOneShot(soundTypes type)
    {
        FXSource.clip = soundType.sounds[type];
        FXSource.PlayOneShot(FXSource.clip);
    }

    public void Stop()
    {
        FXSource.Stop();
    }
    

    public class Soundtype
    {
        public Dictionary<soundTypes, AudioClip> sounds = new Dictionary<soundTypes, AudioClip>();

        public Soundtype(AudioClip[] clips)
        {
            sounds.Add(soundTypes.walk, clips[0]);
            sounds.Add(soundTypes.arrow, clips[1]);

        }
    }
}

public enum soundTypes
{
    walk,
    arrow
}