using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject katanaPrefab;
    [SerializeField] private float force = 450.0f;
    [SerializeField] private Transform pointer;

    private Camera aRCamera;
    void Start()
    {
        aRCamera = GameManager.Instance.ARCamera;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)){
            Vector3 inputPosition = Input.GetMouseButtonDown(0) ? Input.mousePosition : Input.GetTouch(0).position;

            Ray ray = aRCamera.ScreenPointToRay(inputPosition);

            Vector3 diretion;
            if(Physics.Raycast(ray, out RaycastHit cut)){
                diretion = cut.point - pointer.position;
            }else{
                diretion = pointer.forward;
            }
            GameObject katana = Instantiate(katanaPrefab, pointer.position, Quaternion.identity, transform);
            katana.GetComponent<Rigidbody>().AddForce(diretion.normalized*force);
        }
    }
}
