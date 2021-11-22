using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
   [SerializeField] private int addTime = 10;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if(other.CompareTag("Player"))
      {
         GameManager.Instance.time += addTime;
         Destroy(gameObject, 0.1f);
      }
   }
}
