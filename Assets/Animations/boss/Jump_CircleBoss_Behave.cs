using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_CircleBoss_Behave : StateMachineBehaviour
{
    private int randBehaviour;
    private float cycleTime;
    private int randCycles;
    private float randCyclesTime;

    public int minCycles;
    public int maxCycles;

    public float maxJumpAmp;

    private Transform playerPos;

    private Vector2 playerVec;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("jump");


        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerVec = new(playerPos.position.x, animator.transform.position.y);

        cycleTime= stateInfo.length;


        randCycles = Random.Range(minCycles, maxCycles+1);
        randCyclesTime = (cycleTime * randCycles)-(cycleTime/2);

        randBehaviour = Random.Range(0, 3);

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (randCyclesTime <= 0)
        {
            switch (randBehaviour)
            {

                case 2:
                    animator.SetTrigger("follow");
                    
                    break;
                case 1:
                    animator.SetTrigger("walk");
                    break;
                case 0:
                    animator.SetTrigger("idle");
                    break;
            }

            
        }
        else
        {
            randCyclesTime -= Time.deltaTime;
        }

        
        animator.GetComponentInParent<Transform>().position = Vector2.MoveTowards(animator.transform.position, playerVec, maxJumpAmp * Time.deltaTime);


    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("jump");
    }


}



