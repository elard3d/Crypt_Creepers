using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNewEnemy());
    }

    IEnumerator SpawnNewEnemy()
    {
        while (true)
        {
            yield return new  WaitForSeconds(3);
            Instantiate(enemyPrefab);
        }
    }
    
}
