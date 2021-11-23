using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject checkPointPrefab;
    [SerializeField] private int checkPointSpawnDeley = 10;
    [SerializeField] private float spawnRadius = 10 ;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Cada cierto tiempo se crea una nueva instancia de CHECKpoint
        StartCoroutine(SpawnCheckPointRoutine());
    }

    IEnumerator SpawnCheckPointRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkPointSpawnDeley);
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            Instantiate(checkPointPrefab, randomPosition, Quaternion.identity);
        }
    }
}
