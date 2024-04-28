using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
     [Header("Patrolling")]
     public Collider area;
     public float destinationPrecision;
     [Header("Attacking")]
     public float detectionRange = 5;
     public float shootDelay = 3;
     private float elapsedShootDelay = 0;
     
     [Header("References")]
     public Transform player;
     public GameObject tower;
     public GameObject bullet;
     public Transform bulletSpawnPoint;
     public GameObject explosion;
     
     private NavMeshAgent _agent;
     private Rigidbody _rb;
     private enum State
     {
          Chasing,
          Patrolling
     }
     private State state = State.Patrolling;
     private float life = 2;

     private void Start()
     {
          _agent = GetComponent<NavMeshAgent>();
          _rb = GetComponent<Rigidbody>();
     }

     private void Update()
     {
          _rb.velocity = Vector3.zero;
          if(player == null)
               return;
          if (Vector3.Distance(transform.position, player.position) < detectionRange)
          {
               state = State.Chasing;
               if (Vector3.Distance(transform.position, player.position) < 4)
               {
                    _agent.isStopped = true;
               }
               else
               {
                    _agent.isStopped = false;
               }
          }
          else
          {
               state = State.Patrolling;
          }

          elapsedShootDelay += Time.deltaTime;

          switch (state)
          {
               case State.Patrolling:
                    _agent.isStopped = false;
                    if (Vector3.Distance(transform.position, _agent.destination) < destinationPrecision)
                    {
                         _agent.SetDestination(GetNewDestination());
                    }
                    break;
               
               case State.Chasing:
                    _agent.SetDestination(player.position);
                    Vector3 dir = transform.position - player.position;
                    dir.Normalize();
                    tower.transform.rotation = quaternion.LookRotation(-dir, transform.up);
                    tower.transform.eulerAngles = new Vector3(0, tower.transform.eulerAngles.y, 0);
                    if (elapsedShootDelay > shootDelay)
                    {
                         elapsedShootDelay = 0;
                         Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                    }
                    break;
          }
     }

     public Vector3 GetNewDestination()
     {
          Vector3 center = area.bounds.center;
          Vector3 size = area.bounds.size;

          float randomX = Random.Range(-size.x / 2f, size.x / 2f);
          float randomZ = Random.Range(-size.z / 2f, size.z / 2f);
          
          Vector3 newDest = center + new Vector3(randomX, transform.position.y, randomZ);
          newDest.y = transform.position.y;
          return newDest;
     }

     private void OnTriggerEnter(Collider other)
     {
          if (other.CompareTag("Bullet"))
          {
               Destroy(other.gameObject);
               Instantiate(explosion, transform);
               life--;
               if (life < 1)
               {
                    EndManager.instance.enemyList.Remove(gameObject);
                    Destroy(gameObject);
               }
          }
     }
}


