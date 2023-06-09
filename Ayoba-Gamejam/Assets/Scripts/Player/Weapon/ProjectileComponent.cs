using System.Collections;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    ProjectileSystem m_projectileSystem;
    bool m_isActive = false;

    Vector3 m_direction = Vector3.zero;
    float m_speed = 0;


    private void Start()
    {
        m_projectileSystem = ProjectileSystem.GetInstance();
        m_projectileSystem.RegisterProjectile(this);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (m_isActive)
        {
            transform.Translate(m_direction * m_speed * Time.deltaTime);
        }
    }

    internal void FireProjectile(Vector3 _direction, float _speed)
    {
        m_isActive = true;
        m_direction = _direction;
        m_speed = _speed;
        
        
        //look at changing this maybe
        StartCoroutine(DisableObjectDelayed(5));
    }

    private void OnTriggerEnter(Collider collision)
    {
        m_isActive = false;
        gameObject.SetActive(false);


        StopAllCoroutines();
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyComponent enemy = collision.gameObject.GetComponent<EnemyComponent>();
            enemy.health -= 1;


            if (enemy.health <= 0)
            {
                enemy.Death();
            }
            Destroy(gameObject);


        }
        else{
           // Destroy(gameObject);
 }

       
    }


    private IEnumerator DisableObjectDelayed(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        m_isActive = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if (m_projectileSystem != null) { m_projectileSystem.UnregisterProjectile(this); }
    }
}
