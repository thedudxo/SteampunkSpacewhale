using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blender : MonoBehaviour
{
    [SerializeField] float rotationForce;
    Quaternion stopRotation;

    // Start is called before the first frame update
    void Start()
    {
        stopRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
