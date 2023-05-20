using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamager : MonoBehaviour
{
    public float baseDamage=10;

    public bool isDamagingOverTime = false;
    public float damageOverTime = 1.2f;

    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<LayerMask>()==enemyLayer) 
        { 
            //get enemy health controller, apply base damage plus any stacking damage over time.
        }
    }
}
