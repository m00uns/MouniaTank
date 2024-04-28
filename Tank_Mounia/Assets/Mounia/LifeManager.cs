using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    private int actualLife = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
        if (other.CompareTag("LoseZone"))
        {
            Destroy(gameObject);
        }
    }
}
