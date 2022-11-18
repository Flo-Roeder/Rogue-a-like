using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_CircleBoss_Behave : StateMachineBehaviour
{
    private int randBehaviour;

    private float randTime;
    public float minTime;
    public float maxTime;

    private Transform playerPos;
    private Vector2 playerVec;
    public float speed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("jump");

        randBehaviour = Random.Range(0,3);
        randTime = Random.Range(minTime, maxTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (randTime<=0)
        {
            switch (randBehaviour)
            {

                case 0:
                    animator.SetTrigger("idle");
                    break;
                case 1:
                    animator.SetTrigger("walk");
                    break;
                case 2:
                    animator.SetTrigger("jump");
                    break;
            }

        }
        else
        {
            playerPos= GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            playerVec = new(playerPos.position.x, animator.transform.position.y);
            animator.GetComponentInParent<Transform>().position = Vector2.MoveTowards(animator.transform.position, playerVec, speed * Time.deltaTime);
            randTime -= Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("follow");

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
