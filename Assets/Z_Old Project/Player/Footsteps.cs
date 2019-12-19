﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {

    private AudioSource audio;
    public bool ground = true;
    private Animator anim;

    private void Start() {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        Ray ray;
        RaycastHit hit;
        ray = new Ray(transform.position, -PController.Instance.myNormal);
        if (Physics.Raycast(ray, out hit, 1.3f)) {
            ground = true;
        } else {
            ground = false;
        }
        if (Input.GetAxis("Vertical") != 0 && ground || Input.GetAxis("Horizontal") != 0 && ground) {
            anim.SetBool("Walk/Jump", true);
        } else {
            anim.SetBool("Walk/Jump", false);
        }
        if (!ground) {
            anim.SetBool("Walk/Jump", false);
        }
    }

    void FootstepAudio() {
        audio.volume = Random.Range(0.4f, 0.7f);
        audio.pitch = Random.Range(0.8f, 1.1f);
        audio.Play();
	}
}