using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class EnemyComponent : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager manager;
    NavMeshAgent m_navmeshAgent;
    Animator m_animator;
    public int navmeshRange = 5;
    public GameObject prefab;
    public Transform shootpos;
    public float projectile_speed;

    public int health;

    public float countup;
    public float delayCD;


    private void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        EnemyManager.GetInstance().RegisterEnemy(this);
        m_navmeshAgent = GetComponent<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
        countup = 1 / 2 * delayCD;
    }


    private void Update()
    {
        float distance = (Vector3.Distance(this.transform.position, manager.player.transform.position));

        if (distance < manager.detect_distance)
        {
            m_navmeshAgent.SetDestination(manager.player.transform.position);

            countup += 0.1f;
            if (countup > delayCD)
            {
                Attack();
                countup = 0;

            }

            
        }
        else
        {
            m_navmeshAgent.SetDestination(RandomNavmeshLocation(navmeshRange));
        }
        
       
    }
    private void OnDestroy()
    {
        if (EnemyManager.GetInstance())
        {
            EnemyManager.GetInstance().UnregisterEnemy(this);
        }
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    public void Attack()
    {
        GameObject Projectile = Instantiate(prefab, shootpos.position + Vector3.up, Quaternion.identity);

        Vector3 direction = (manager.player.transform.position - shootpos.position).normalized;

        EnemyProjectile proj = Projectile.GetComponent<EnemyProjectile>();
        proj.dir = direction;
        proj.proj_speed = projectile_speed;
        
        
        //Projectile.transform.Translate(direction * projectile_speed * Time.deltaTime);
        
       
        
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }


}
