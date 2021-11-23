using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject checkPointPrefab;
    [SerializeField] private int checkPointSpawnDeley = 10;
    [SerializeField] private int powerUpSpawnDeley = 12;
    [SerializeField] private float spawnRadius = 10 ;
    [SerializeField] GameObject[] powerUpPrefab ;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Cada cierto tiempo se crea una nueva instancia de CHECKpoint
        StartCoroutine(SpawnCheckPointRoutine());
        
        //Cada cierto tiempo se creara una nueva instancia de PowerUp
        StartCoroutine(SpawnPowerUpRoutine());
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

    IEnumerator SpawnPowerUpRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(powerUpSpawnDeley); 
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            int random = Random.Range(0, powerUpPrefab.Length);
            Instantiate(powerUpPrefab[random], randomPosition, Quaternion.identity);
        }
    }
}
