using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{

    [Header("References")]
    public Transform player;
    

    [Header("Variables")]
    public Vector3 CamPos;
    public Vector3 offset;
    public Vector3 OriginPos;
    public float Lerp;
    public bool CamFollow;
    public int clampMin;
    public int clampMax;


    private void Start()
    {
        player = GameObject.Find("Player").transform;
        CamPos = transform.position;
        OriginPos = CamPos;
        CamFollow = true;

    }

    private void Update()
    {



        if (CamFollow)
        {
            OriginPos = CamPos;

            CamPos = Vector3.Lerp(CamPos, player.position, Lerp);
            CamPos = new Vector3(OriginPos.x, OriginPos.y, CamPos.z + offset.z);
            
            CamPos.z = Mathf.Clamp(CamPos.z, clampMin, clampMax);


            transform.position = CamPos;
        }







    }
}
