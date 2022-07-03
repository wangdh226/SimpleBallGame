using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;


/* Helper class for AudioManager so that I don't have to add AudioManager into the prefab
 *   (so I don't have to add it to every scene - AudioManager will run once on main menu and then persist throughout scenes)
 */
public class AudioManagerHelper : MonoBehaviour
{
    AudioManager am;

    void Start()
    {
        am = AudioManager.instance;
        instantiateSlider("BGM");
        instantiateSlider("SFX");
    }

    // Method to update/persist slider position for each scene that has options menu
    private void instantiateSlider(string name) {
        Slider slider = GameObject.Find("Audio Slider - " + name).GetComponent<Slider>();
        Sound sound = Array.Find(am.sounds, sound => sound.name.Contains(name));
        slider.value = sound.source.volume;
    }

    public void Play(string name) { 
        am.Play(name);
    }

    public void Stop(string name) {
        am.Stop(name);
    }

    public void Mute(string name) {
        am.Mute(name);
    }

    public void VolumeBGM(float volume) {
        am.VolumeBGM(volume);
    }

    public void VolumeSFX(float volume) {
        am.VolumeSFX(volume);
    }
}
