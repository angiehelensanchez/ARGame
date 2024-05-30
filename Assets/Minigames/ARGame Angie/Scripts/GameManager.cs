using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Camera ARCamera ;
    [SerializeField] private TextMeshProUGUI scoreText;

    private float currentScore = 0;

     [SerializeField] public GameObject[] fruits;
    public float globaltime = 60.0f;


    private void Awake()
    {
        if(Instance!= this && Instance != null){
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }
    void Start()
    {   
        ARCamera = GameManager.Instance.ARCamera;
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        //if (globaltime == 10.0f)
        //{
        //    for (var i = 6; i >= 0; i--)
        //    {
        //        scoreText.text = string.Format("El juego empieza en {0}s", i);
        //        yield return new WaitForSeconds(1);
        //    }
        //    scoreText.text = "Score: " + currentScore.ToString();
        //}

        var ARCameraTransform = ARCamera.transform;
        yield return new WaitForSeconds(3);

        float randomX = UnityEngine.Random.Range(-1.0f, 1.0f);
        float randomY = UnityEngine.Random.Range(-1.0f, 1.0f);
        Vector3 spawnOffset = new Vector3(randomX, randomY, 1.0f);
        Vector3 spawnPosition = ARCameraTransform.position + ARCameraTransform.TransformDirection(spawnOffset);

        int randomFruitIndex = UnityEngine.Random.Range(0, fruits.Length);


        Instantiate(fruits[randomFruitIndex], spawnPosition, Quaternion.identity);

        globaltime -= 3.0f;


        if (globaltime > 3)
        {
            StartCoroutine(StartSpawning());
        }
        else
        {
            scoreText.text = "Has conseguido: " + currentScore.ToString() + " puntos";

            int intScore = Mathf.RoundToInt(currentScore);
            PlayerPrefs.SetInt("ScoreAngie", intScore);
            PlayerPrefs.Save();
            StartCoroutine(WaitAndLoadPuntuacionAngie());
        }
    }
    public void UpdateScore(float points){
        currentScore += points;
        scoreText.text=string.Format("Score: {0}", currentScore);
    }

    IEnumerator WaitAndLoadPuntuacionAngie()
    {
        // Wait for 5 seconds before loading the new scene
        yield return new WaitForSeconds(5);

        // Load the new scene
        SceneManager.LoadScene("PuntuacionAngie");
    }


 


}
