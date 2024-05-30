using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    [SerializeField] private AudioSource themeSong;
    private int score = 0;
    public int endGameScore = 3;
    

    void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        if (themeSong != null)
        {
            themeSong.Play();
        }
    }

    public void AddScore(int points)
    {
        Debug.Log("Adding score: " + points);
        score += points;
        UpdateScoreUI();
        CheckEndGameCondition();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    void CheckEndGameCondition()
    {
        if (score >= endGameScore)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("Has conseguido: " + score + " puntos");
        if (themeSong != null)
        {
            themeSong.Stop();
        }

        PlayerPrefs.SetInt("ScoreIzan", score);
        PlayerPrefs.Save();

        SceneManager.LoadScene("PuntuacionIzan");
    }
}
