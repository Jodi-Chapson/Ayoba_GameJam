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
    private void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        EnemyManager.GetInstance().RegisterEnemy(this);
        m_navmeshAgent = GetComponent<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
    }


    private void Update()
    {
        float distance = (Vector3.Distance(this.transform.position, manager.player.transform.position));

        if (distance < manager.detect_distance)
        {
            m_navmeshAgent.SetDestination(manager.player.transform.position);
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
        //this.GetComponent < WeaponComponent>().FireWeapon(this.gameObject.transform.position + Vector3.up, target);

        //Vector3 direction = (_target - _startPosition).normalized;
       // transform.Translate(m_direction * m_speed * Time.deltaTime);
    }


}
