using UnityEngine;
using UnityEngine.Audio;
using System;

/* 
 * AudioManager.cs and Sound.cs created following https://www.youtube.com/watch?v=6OT43pvUyfY
 */
public class AudioManager : MonoBehaviour {

    public static AudioManager instance;
    
    public Sound[] sounds;

    void Awake() {
        if (instance == null) {
            // if the AudioManager does not exist, create one and associate components
            instance = this;
            DontDestroyOnLoad(gameObject);

            foreach (Sound s in sounds) {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.currentVolume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        } else {
            // if the AudioManager already exists, destroy the new instance
            //   only used if loading AudioManager in multiple scenes i think
            Destroy(gameObject);
        }
    }

    void Start() {
        Play("BGM_Main");
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null) {
            s.source.volume = s.currentVolume;
            s.source.pitch = s.pitch;
            s.source.Play();
        } else {
            Debug.LogWarning("Sound: " + name + " not found");
        }
    }

    public void Stop(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null) {
            s.source.Stop();
        } else {
            Debug.LogWarning("Sound: " + name + " not found");
        }
    }

    public void Mute(string name) {
        Sound[] soundList = Array.FindAll(sounds, sound => sound.name.Contains(name));
        foreach (Sound s in soundList) {
            if (s.source.volume == 0) {
                s.currentVolume = s.previousVolume;
            } else {
                s.previousVolume = s.currentVolume;
                s.currentVolume = 0;
            }
            s.source.volume = s.currentVolume;
        }
    }

    public void VolumeBGM(float volume) {
        Sound[] soundList = Array.FindAll(sounds, sound => sound.name.Contains("BGM"));
        foreach (Sound s in soundList) {
            s.currentVolume = volume;
            s.source.volume = volume;
        }
    }

    public void VolumeSFX(float volume) {
        Sound[] soundList = Array.FindAll(sounds, sound => sound.name.Contains("SFX"));
        foreach (Sound s in soundList) { 
            s.currentVolume = volume;
            s.source.volume = volume;
        }
    }
}
