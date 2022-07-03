using UnityEngine;
using UnityEngine.Audio;
using System;

/* 
 * AudioManager.cs and Sound.cs created following https://www.youtube.com/watch?v=6OT43pvUyfY
 */
public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake() {
        if(instance == null) {
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
            Destroy(gameObject);
        }
    }

    void Start() {
        Play("BGM");
    }

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null) {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        s.source.Play();
    }

    public void Stop(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        s.source.Stop();
    }

}
