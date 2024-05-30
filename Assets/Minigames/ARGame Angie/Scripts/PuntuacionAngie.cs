
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuntuacionAngie : MonoBehaviour
{

    public TextMeshProUGUI puntuacionTxt;


    // Start is called before the first frame update
    void Start()
    {

        float puntuacion = PlayerPrefs.GetInt("ScoreAngie", 0);
        puntuacionTxt.text = $"Puntos obtenidos: {puntuacion} pts";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("WildFruits");
    }

    public void NextGame()
    {

        SceneManager.LoadScene("EscenaFinal");

    }
}

