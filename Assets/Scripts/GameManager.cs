using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int time = 30;
    public int dificulty = 1;

    [SerializeField] private int score;

    public int Score
    {
        get => score;
        set
        {
            //asigana variable y valor a la propiedad
            score = value;
            if (score % 1000 == 0)
            {
                dificulty++;
            }
        }
    }
    
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
