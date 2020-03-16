using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour {

    public Animator anim;
    public SpriteRenderer sr;
    public GameObject interacter;
    public Vector2 facing; 
    public bool isAiming; //is the player in the aiming state
    public Transform trans;
    [Range(0f, 1f)] public float inputThreshold;

    public AudioClip deathSound;
    public AudioClip pickupSound;
    public AudioClip attackSound;
    public AudioClip moveSound;

    public int score;


    void Awake() {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        interacter = GetComponentInChildren<PlayerInteracter>().gameObject;
        facing = new Vector2(1, 0);

    }

    private void Update() {
        trans = interacter.GetComponent<BoxCollider2D>().transform;
    }

    public void PlayerDeath() {
        TempSoundPlayer sp = Instantiate(Resources.Load("TempSoundPlayer") as GameObject).GetComponent<TempSoundPlayer>();
        sp.playSound(deathSound);
        SceneManager.LoadScene("Game Over");
    }

}
