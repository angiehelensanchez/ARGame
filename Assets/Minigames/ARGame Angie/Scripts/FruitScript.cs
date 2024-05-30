using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private float timer = 0;
    [SerializeField] private float autoDestroyTime = 5.0f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 0.01f);
        timer += Time.deltaTime;
        if(timer>autoDestroyTime){
            Destroy(gameObject);
        }
    }
}
