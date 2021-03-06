using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private int healt = 3;

    public bool powerShot;

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<EnemyScript>().TakeDamage();
                if (!powerShot)
                    Destroy(gameObject);
                healt--;
                
                if (healt<=0)
                {
                    Destroy(gameObject);
                }
            }
        }
}
