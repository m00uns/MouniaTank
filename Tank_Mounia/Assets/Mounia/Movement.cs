using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed;
    public float torqueSpeed;
    private Rigidbody _rb;

    private Vector2 moveVector;
    private TemporaryPlatform actual = null;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();                                 
    }

    public void InputPlayer(InputAction.CallbackContext context)         
    {
        moveVector = context.ReadValue<Vector2>();
        actual.used = true;
    }

    void Update()
    {        
        //Direction normalized
        Vector3 direction = new Vector3(moveVector.x, 0, moveVector.y);
        direction.Normalize();
        
        //Turn in inputs direction
        float singleStep = torqueSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, singleStep, 0.0f);
        transform.rotation = quaternion.LookRotation(newDirection, transform.up);
        
        //Always go forward
        Vector3 newVelocity = transform.forward * (direction.magnitude * speed);
        newVelocity.y = _rb.velocity.y;
        _rb.velocity = newVelocity;
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.transform.TryGetComponent(out TemporaryPlatform tp))
        {
            actual = tp;
        }
    }
}

