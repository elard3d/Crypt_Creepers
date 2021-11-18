using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private int health = 1;

    public void TakeDamage()
    {
        health--;
    }
}
