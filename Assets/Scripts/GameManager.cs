using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int time = 30;
    [SerializeField] public int dificulty = 1;
    
    //Patron de Diseño Singleton
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; //retorna toda la info de GameMAnager
        }
    }

    private void Start()
    {
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine()
    {
        while (time>0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
        
        //GAMEOVER
        
        Debug.Log("GAMEOVER");
    }
}
