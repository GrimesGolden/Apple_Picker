using UnityEngine.Audio;
using UnityEngine;

[System.Serializable] //needs to be marked so it shows up in unity inspector. 
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    // Don't show audio source in inspector, because we already named it above. 
    [HideInInspector]
    public AudioSource source;
}
