using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour {

    private AudioSource audio_source;

    private AudioClip[][] master_set;
    public AudioClip[] clips_set_1;
    public AudioClip[] clips_set_2;
    public AudioClip[] clips_set_3;

    void Awake() {
        audio_source = GetComponent<AudioSource>();
        master_set = new AudioClip[][] { clips_set_1, clips_set_2, clips_set_3 };
    }

    void Update() {
    }

    /*
    public void playSound() {
        playSound(0);
    }
    */

    public void playSound(int set) {
        AudioClip[] clip_set = master_set[set];
        Assert.IsTrue(clip_set.Length > 0, "Clips array is empty");
        AudioClip clip = clip_set[Random.Range(0, clip_set.Length)];
        audio_source.PlayOneShot(clip);
    }

}