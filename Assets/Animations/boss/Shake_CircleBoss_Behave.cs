using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake_CircleBoss_Behave : StateMachineBehaviour
{
    private int randBehaviour;
    private int randCycles;
    private float cycleTime;
    private float randCyclesTime;

    public int minCycles;
    public int maxCycles;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("walk");


        randCycles = Random.Range(minCycles, maxCycles);
        cycleTime = stateInfo.length;
        randCyclesTime = (randCycles * cycleTime)-(cycleTime/2);

        randBehaviour = Random.Range(0, 3);

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (randCyclesTime <= 0)
        {


            switch (randBehaviour)
            {

                case 0:
                    animator.SetTrigger("jump");
                    break;
                case 2:
                    animator.SetTrigger("follow");
                    break;
                case 1:
                    animator.SetTrigger("idle");
                    break;
            }
        }
        else
        {
            randCyclesTime -= Time.deltaTime;
        }


    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("walk");
    }

}
