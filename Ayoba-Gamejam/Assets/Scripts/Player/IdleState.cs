using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class IdleState : StateMachineBehaviour
{
    public const string MOVE_STATE = "Move";
    public const string FIRE_STATE = "Fire";

    WidgetController m_widgetController;
    EnemyManager m_enemyManager;


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

        animator.ResetTrigger(MOVE_STATE);
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (m_widgetController.GetDirection() != Vector3.zero)
        {
            animator.SetTrigger(MOVE_STATE);
            animator.ResetTrigger(MoveState.IDLE_STATE);


            //GameObject gun = GameObject.Find("Meat_Gun");
            //gun.GetComponent<MeshRenderer>().enabled = false;

            GameObject manager = GameObject.Find("Game Manager");
            manager.GetComponent<GameManager>().Switch("base");
        }
        else if (m_enemyManager.TargetExists()) {
            animator.ResetTrigger(MoveState.IDLE_STATE);
            animator.SetTrigger(FIRE_STATE);

            GameObject manager = GameObject.Find("Game Manager");
            manager.GetComponent<GameManager>().Switch("shoot");
        }
    }
}

