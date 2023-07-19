using UnityEngine.Audio;
using UnityEngine;

//Done by Jaina
[System.Serializable]
public class SoundScript
{
    public string name;

    public AudioClip clip;

    [Range(0f,1f)] 
    public float volume;
    [Range(.1f,3f)] 
    public float pitch;

    public bool loop;

    [HideInInspector] 
    public AudioSource source;
}
