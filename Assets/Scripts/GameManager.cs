using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public GameObject rate;
    public float SpawnInterval = 1.0f;
    private int pom_score = 0;

    public enum GameState
    {
        Playing,
        Pause,
        GameOver
    }

    public Text Score;

    public GameState _currentState = GameState.Playing;
    private int _score = 0;

    void Awake()
    {
        GM = this;

        Score.text = _score.ToString();
    }
    
    public void AddScore(int amount)
    {
        _score += amount;
        pom_score += amount;

        if (pom_score >= 12 && SpawnInterval > 0.21f)
        {
            SpawnInterval -= 0.2f;
            pom_score = 0;
        }

        Score.text = _score.ToString();
    }
}
