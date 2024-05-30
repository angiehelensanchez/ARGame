using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaController : MonoBehaviour
{
    [SerializeField] private float autoDestroyTime = 20.0f;
    private float timer = 0;
    public GameObject smoke;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer>autoDestroyTime){
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Fruit")){
            var pos = collision.gameObject.transform;
            Destroy(collision.gameObject);
            Instantiate(smoke, pos.position, Quaternion.identity);
            GameManager.Instance.UpdateScore(5.0f);
        }
    }
}
