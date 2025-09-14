using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance; 

    void Awake()
    {
        if (instance == null)
        {
            // Initial creation of audio manager. 
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return; 
        }
        
        // Permits the audio manager to persist between scenes
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(String name)
    {
        // Using system, search through sounds array for matching name. 
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            // Prevents null error in the case of mismatched name. 
            Debug.Log("Sound: " + name + " not found!");
            return;
        }
        s.source.Play(); 
    }
    public void Stop(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound not found: " + name);
            return;
        }
        s.source.Stop();
    }

    public void StopAll() {
        foreach (Sound s in sounds) {
            s.source.Stop();
        }
    }
}
