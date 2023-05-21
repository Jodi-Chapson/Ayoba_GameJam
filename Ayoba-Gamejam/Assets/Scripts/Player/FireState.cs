using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireState : StateMachineBehaviour
{
    bool m_canFire = false;

    WidgetController m_widgetController;
    EnemyManager m_enemyManager;
    WeaponComponent m_weaponComponent;

    private Transform ShootingPos;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (m_widgetController == null)
        {
            m_widgetController = WidgetController.GetInstance();
        }

        if (m_enemyManager == null)
        {
            m_enemyManager = EnemyManager.GetInstance();
        }

        if (m_weaponComponent == null) { m_weaponComponent = animator.GetComponent<WeaponComponent>(); }
        m_canFire = true;


        

        
    }

    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 target = m_enemyManager.GetNearestTarget(animator.transform.position);
        if (target != Vector3.zero)
        {
            //Hack for transform at feet height
            target.y = animator.transform.position.y + 1;

            if (m_canFire)
            {
                m_canFire = false;
                ShootingPos = GetChildWithName(animator.gameObject, "ShootingPoint").transform;


                m_weaponComponent.FireWeapon(ShootingPos.position + Vector3.up, target);
            }
            else { animator.SetTrigger(MoveState.IDLE_STATE);
                animator.ResetTrigger(IdleState.FIRE_STATE);
                

                GameObject manager = GameObject.Find("Game Manager");
                manager.GetComponent<GameManager>().Switch("base");

            }
        }

        if (m_widgetController.GetDirection() != Vector3.zero)
        {
            animator.SetTrigger(IdleState.MOVE_STATE);
            animator.ResetTrigger(IdleState.FIRE_STATE);
            
            

            GameObject manager = GameObject.Find("Game Manager");
            manager.GetComponent<GameManager>().Switch("base");

        }
    }

    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 target = m_enemyManager.GetNearestTarget(animator.transform.position);
        if (target != Vector3.zero)
        {
            //Hack for transform at feet height
            target.y = animator.transform.position.y + 1;
            animator.gameObject.transform.LookAt(target);
        }
    }
}






