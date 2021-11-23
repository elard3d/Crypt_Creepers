using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    private float originalSpeed;

    private PlayerScript player;

    [SerializeField ]private float speedReductionRstio = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        originalSpeed = player.speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Al entrar al agua
        if (other.CompareTag("Player"))
        {
            player.speed *= speedReductionRstio;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //al salir
        if (other.CompareTag("Player"))
        {
            player.speed = originalSpeed;
        }
    }
}
