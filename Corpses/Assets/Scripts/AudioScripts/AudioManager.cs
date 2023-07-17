using UnityEngine.Audio;
using System;
using UnityEngine;

//Done by Jaina
public class AudioManager : MonoBehaviour
{
    public SoundScript[] sounds; //declates a public array of "SoundScript" objects named "sounds"

    public static AudioManager instance;
    void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        //To look through audio list
        foreach (SoundScript s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();//Sets the volume, pitch, and loop properties of the AudioSource to the corresponding values specified in the current SoundScript object.
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        Play("MainTheme");
    }
    public void Play(string name)
    {

        SoundScript s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name + "not found");
            return;
        }
            
        s.source.Play();

        if(PauseMenu.GameIsPaused)
        {
            s.source.pitch += .5f; //lowers game audio volume
        }
    }
}
