using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    //REferenciar elementos de interfaz
    
    public static UiManager Instance;
    
    [SerializeField] private Text healText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text finalScore;
    [SerializeField] private GameObject gameOverScreen;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void UpdateUIScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
    
    public void UpdateUIHealt(int newHealt)
    {
        healText.text = newHealt.ToString();
    }
    
    public void UpdateUITime(int newTime)
    {
        timeText.text = newTime.ToString();
    }

    //mostrar en pantalla
    public void ShowGameOverScreen()
    {
        
        gameOverScreen.SetActive(true);
        finalScore.text = "" + GameManager.Instance.Score;
    }
    
    
}
