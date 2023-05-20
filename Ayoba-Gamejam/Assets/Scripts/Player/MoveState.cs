using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : StateMachineBehaviour
{
    public const string IDLE_STATE = "Idle";
    public float m_playerSpeed = 20;


    WidgetController m_widgetController;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (m_widgetController == null)
        {
            m_widgetController = WidgetController.GetInstance();
        }
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(IDLE_STATE);
        if (m_widgetController.GetDirection() == Vector3.zero)
        { animator.SetTrigger(IDLE_STATE);
            //GameObject gun = GameObject.Find("Meat_Gun");
            //gun.GetComponent<MeshRenderer>().enabled = true;
            GameObject manager = GameObject.Find("Game Manager");
            manager.GetComponent<GameManager>().Switch("base");
        }
    }

    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 direction = m_widgetController.GetDirection();

        Vector3 lookatPos = animator.transform.position + direction;
        lookatPos.y = animator.transform.position.y;

        animator.transform.LookAt(lookatPos);


        //m_navmeshAgent.SetDestination(manager.player.transform.position);
        //animator.transform.position = animator.transform.position + (direction * m_playerSpeed * Time.deltaTime);
    }



}