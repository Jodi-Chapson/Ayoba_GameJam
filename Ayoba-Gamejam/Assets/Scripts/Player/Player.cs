using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death()
    {
        //ending screen

        GameManager manager = GameObject.Find("Game Manager").gameObject.GetComponent<GameManager>();
        manager.end_panel.gameObject.SetActive(true);


    }
}
