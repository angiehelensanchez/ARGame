using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
    public Transform spawnPoints;
    public GameObject[] fruits;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning(){
        yield return new WaitForSeconds(4);
        var randomx = UnityEngine.Random.Range(-1.0f,2.0f);
        int randomfruit = UnityEngine.Random.Range(0,8);
        Vector3 pos = spawnPoints.position;
        pos.z += randomx;

        Instantiate(fruits[randomfruit],pos, Quaternion.identity);
        StartCoroutine(StartSpawning());
        GameManager.Instance.UpdateScore(5.0f);
    }
    
}
