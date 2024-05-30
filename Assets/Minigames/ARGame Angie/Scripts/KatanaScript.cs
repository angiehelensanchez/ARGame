using UnityEngine;
using System.Collections;
using System;
using Unity.VisualScripting;
using JetBrains.Annotations;


public class KatanaScript : MonoBehaviour
{
    public Transform cameraposition;
    public GameObject katanaPrefab;
    private GameObject katanaActual;

    // Start is called before the first frame update
    void Start()
    {
        katanaActual = Instantiate(katanaPrefab, cameraposition.position, Quaternion.identity);
        StartCoroutine(PositionKatanaRound());
    }  
       
    public IEnumerator PositionKatanaRound(){
        while(true){
            yield return new WaitForSeconds(0.0F);
            if(katanaActual!=null){

                Vector3 katanaRelativePosition = new Vector3(0f,-1f,1.1f);
                Quaternion cameraRotation = cameraposition.rotation;
                Vector3 katanaGlobalPosition = cameraposition.transform.TransformPoint(katanaRelativePosition);
                Quaternion katanaGlobalRotation = cameraposition.transform.rotation * cameraRotation;

                katanaActual.transform.position = katanaGlobalPosition;
                katanaActual.transform.rotation = katanaGlobalRotation;
            }            
        
        }
       
    }

}
