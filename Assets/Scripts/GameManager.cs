using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public delegate void PlayerDeath();
    public delegate void PlayAgain();
    public static event PlayerDeath OnPlayerDeath;
    public static event PlayAgain OnPlayAgain;

    public GameObject GameOverScreen;

    public static Action OnUpdateScore;

    private void OnEnable()
    {
        OnUpdateScore += UpdateScoreUI;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        GameOverScreen.SetActive(false);
        OnPlayerDeath += ShowGameOverScreen;

    }

    private void ShowGameOverScreen()
    {
        GameOverScreen.SetActive(true);
    }

    public void PlaterKilled()
    {
        OnPlayerDeath?.Invoke();
    }

    public void Playagain()
    {
        GameOverScreen.SetActive(false);
        OnPlayAgain?.Invoke();
    }

    public void UpdateScoreUI()
    {
        Debug.Log("Score Update");
    }
}
