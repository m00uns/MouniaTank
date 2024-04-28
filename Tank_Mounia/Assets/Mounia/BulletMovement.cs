using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 20;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rb.velocity = transform.forward * speed;
    }
}
