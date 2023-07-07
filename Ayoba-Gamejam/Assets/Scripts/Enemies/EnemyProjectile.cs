using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float proj_speed;
    public Vector3 dir;
    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(dir * proj_speed * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("oop");
            Player player = collision.gameObject.GetComponent<Player>();
            player.health -= 1;
            if (player.health <= 0)
            {
                player.Death();
            }

            Destroy(this.gameObject);

        }

        else if (collision.gameObject.tag == "Terrain")
        {
            Destroy(this.gameObject);

        }
        
        
    


       
    }
}
