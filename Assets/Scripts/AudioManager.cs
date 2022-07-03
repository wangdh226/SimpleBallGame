using UnityEngine;
using UnityEngine.Audio;
using System;

/* 
 * AudioManager.cs and Sound.cs created following https://www.youtube.com/watch?v=6OT43pvUyfY
 */
public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake() {
        if (instance == null) {
            // if the AudioManager does not exist, create one and associate components
            instance = this;
            DontDestroyOnLoad(gameObject);

            foreach (Sound s in sounds) {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
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
        Play("BGM");
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null) {
            s.source.volume = s.volume;
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
}
