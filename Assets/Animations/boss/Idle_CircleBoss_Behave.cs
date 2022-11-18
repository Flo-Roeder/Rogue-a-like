using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle_CircleBoss_Behave : StateMachineBehaviour
{
    private int randBehaviour;
    private int randCycles;
    private float cycleTime;
    private float randCyclesTime;
    
    public int minCycles;
    public int maxCycles;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("idle");

        cycleTime = stateInfo.length;

        randCycles = Random.Range(minCycles, maxCycles+1);

        randCyclesTime = (randCycles * cycleTime)-(cycleTime/2);

        randBehaviour = Random.Range(0, 3);

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (randCyclesTime<=0)
        {


            switch (randBehaviour)
            {

                case 0:animator.SetTrigger("jump");
                    break;
                case 1:animator.SetTrigger("walk");
                    break;
                case 2:
                    animator.SetTrigger("follow");
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
        animator.ResetTrigger("idle");
    }


}
