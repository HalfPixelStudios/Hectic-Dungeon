using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//One time use sound player

[RequireComponent(typeof(AudioSource))]
public class TempSoundPlayer : MonoBehaviour {

    private AudioSource audio_source;

    private bool sound_started;

    void Awake() {
        audio_source = GetComponent<AudioSource>();
        audio_source.volume = 0.5f;
    }

    void Update() {

        if (!audio_source.isPlaying && sound_started) {
            Destroy(this.gameObject);
        }
    }

    public void playSound(AudioClip sound) {
        audio_source.clip = sound;
        audio_source.Play();
        sound_started = true;
    }

    public void setVolume(float volume) {
        audio_source.volume = volume;
    }
}