using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Shoot : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    private float torqueSpeed = 10;
    private Vector2 aimVector;

    [Header("References")] public GameObject tower;
    
    public void InputPlayer(InputAction.CallbackContext context)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        aimVector = context.ReadValue<Vector2>();
    }

    void Update()
    {
        Vector3 direction = new Vector3(aimVector.x, 0, aimVector.y);   
        direction.Normalize();      
        Debug.Log(direction);
        
        float singleStep = torqueSpeed * Time.deltaTime;                                                                      
        Vector3 newDirection = Vector3.RotateTowards(tower.transform.forward, direction, singleStep, 0.0f);                         
        tower.transform.rotation = quaternion.LookRotation(newDirection, tower.transform.up);                                             
    }

    public void TriggerShoot(InputAction.CallbackContext context)
    {
        if (context.started)
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}
