﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catwalk : MonoBehaviour, IResetable  {

    public float fallingSpeed;
    float currentFallingSpeed;
    public float acceleration;
    private bool falling = false;

    private Vector3 startPos;
    private Quaternion startRot;
    private Vector3 startScale;

    [SerializeField] float stopAtY;

    public AudioSource fall;

    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        startScale = transform.localScale;
        currentFallingSpeed = fallingSpeed;
    }

    void FixedUpdate () {
        if (falling)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - currentFallingSpeed, transform.position.z);
            currentFallingSpeed += acceleration;
        }
        if(transform.localPosition.y <= stopAtY) {
            falling = false;
            fall.Stop();
        }
	}

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            Debug.Log("collision");
            falling = true;
            if (!fall.isPlaying){
                fall.Play();
            }
        }
    }

    public void Reset() {
        Debug.Log("Reset");
        transform.position = startPos;
        transform.rotation = startRot;
        transform.localScale = startScale;
        falling = false;
        currentFallingSpeed = fallingSpeed;
        fall.Stop();
    }
}
