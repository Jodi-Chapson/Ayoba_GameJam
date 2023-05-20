using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;


    public void Update()
    {



        this.transform.position = new Vector3(Player.position.x + offset.x, Player.position.y + offset.y, Player.position.z + offset.z);

            
            //Player.position;
    }
}
