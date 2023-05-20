using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public float detect_distance;
    public GameObject b_base;
    public GameObject b_shoot;
    public GameObject b_base_armature;
    public GameObject b_shoot_armature;
    public bool canswitch;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void Switch(string type)
    {
        if (canswitch)
        {
            if (type == "base")
            {
                b_base.gameObject.SetActive(true);
                b_shoot.gameObject.SetActive(false);
                b_base_armature.gameObject.SetActive(true);
                b_shoot_armature.gameObject.SetActive(false);
            }
            else
            {
                b_base.gameObject.SetActive(false);
                b_shoot.gameObject.SetActive(true);
                b_base_armature.gameObject.SetActive(false);
                b_shoot_armature.gameObject.SetActive(true);
            }
        }
    }
    
}
