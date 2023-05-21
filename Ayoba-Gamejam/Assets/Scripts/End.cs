using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager manager = GameObject.Find("Game Manager").gameObject.GetComponent<GameManager>();
            if (manager.Enemies == 0)
            {
                manager.WinScene();

            }
            
            
            
        }
    }
}
