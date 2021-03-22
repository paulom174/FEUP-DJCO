using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    private void Awake() {
    // Awake method is called right before Start()
        foreach (Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name) {
        // Find a sound in the sounds array where sound.name is equal to name
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s != null && s.source.isPlaying == false) s.source.Play();

        
    }

    public void Stop(string name) {
        // Find a sound in the sounds array where sound.name is equal to name
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s != null) s.source.Stop();

    }

}
