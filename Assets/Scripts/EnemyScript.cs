using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Transform player;
    [SerializeField] private int health = 1;
    [SerializeField] private float speed = 1;

    private void Start()
    {
         player = FindObjectOfType<PlayerScript>().transform;
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
    }
}
