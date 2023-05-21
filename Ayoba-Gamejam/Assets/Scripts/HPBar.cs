using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    
   
       
    GameManager manager;
    EnemyComponent enemy;
    Player player;
    public Image healthBar;
    public float maxHP;
    public float currHP;

    void Start()
    {
        
        currHP = maxHP;
        
        if (this.gameObject.tag == "Player")
        {
            player = this.gameObject.GetComponent<Player>(); 
        }
        else
        {
            enemy = this.gameObject.GetComponent<EnemyComponent>();

        }
        




    }

    private void Update()
    {
        if (this.gameObject.tag == "Player")
        {
            currHP = player.health;
        }
        else 

        {
            currHP = enemy.health;

        }

            
        healthBar.fillAmount = currHP / maxHP;


    }
   
    
    
}
