using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public int maxHP=100;
    public int currentHP=100;
    public Image healthbarUI;
    public LayerMask enemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        healthbarUI.fillAmount = currentHP / maxHP;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<LayerMask>()==enemyLayer)
        { 
        TakeDamage(collision.gameObject.GetComponent<EnemyDamager>().baseDamage);
            healthbarUI.fillAmount = currentHP / maxHP;
        }   
    }

    public void TakeDamage(int damageTaken) 
    {
        currentHP = currentHP - damageTaken;
        healthbarUI.fillAmount = currentHP / maxHP;

    }
}
