using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    private Transform player;
    [SerializeField] private int health = 1;
    [SerializeField] private float speed = 1;

    private void Start()
    {
         player = FindObjectOfType<PlayerScript>().transform;
         
         GameObject[] spawnPoint = GameObject.FindGameObjectsWithTag("SpawnPoint");
         int randomSpawnPoint = Random.Range(0, spawnPoint.Length);
         transform.position = spawnPoint[randomSpawnPoint].transform.position;

    }

    private void Update()
    {
        //obtener direccion hacia el jugador
        Vector2 direction = player.position - transform.position;
        transform.position += (Vector3)direction * Time.deltaTime * speed;

    }

    public void TakeDamage()
    {
        health--;
        if (health <=0)
        {
            Destroy(gameObject);
        }
        
    }

}
