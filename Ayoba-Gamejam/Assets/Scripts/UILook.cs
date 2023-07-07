using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILook : MonoBehaviour
{

     private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;

        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                mainCamera.transform.rotation * Vector3.up);
    }
}
