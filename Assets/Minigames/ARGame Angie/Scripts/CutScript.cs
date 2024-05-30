using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CutScript : MonoBehaviour
{
    public GameObject arCamera;
    public GameObject smoke;
    public GameObject katana;
    private KatanaScript katanaScript;
    void Start(){
        katanaScript=katana.GetComponent<KatanaScript>();
    }

    void Update(){
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            
            Debug.Log(katanaScript);
            RaycastHit cut;
            if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out cut)){
                if(cut.transform.CompareTag("Fruit")){
                    Destroy(cut.transform.gameObject);
                    Instantiate(smoke, cut.point, Quaternion.LookRotation(cut.normal));
                }

            }
        }
    }

}
