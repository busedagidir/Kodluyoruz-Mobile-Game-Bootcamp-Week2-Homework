using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text timeUI;
    bool isGameOver = false;
    
    void Start()
    {
        FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
    }

    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space)) //reload the scene
            {
                Time.timeScale = 1; //resume game
                SceneManager.LoadScene(0); //first scene
            }
        }
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        timeUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        isGameOver = true;
        Time.timeScale = 0; //stop game
    }
}