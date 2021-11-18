using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 5;

        void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }
}
