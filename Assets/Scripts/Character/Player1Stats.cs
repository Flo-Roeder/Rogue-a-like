using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Stats : PlayerStatsParent
{
   
 




    void Awake()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        //set the stats in dictionary
        speed = 5f;
        walksmooth = 0f;
        jumpSpeed = jumpSpeed = 15f;
        attackRange = 2.5f;
        attackTime = 0.7f;
        attackCooldown = 0.3f;
        iFramesTime = 1f;
        dashSpeed = 2.8f;
        dashCooldown = 1f;
        possibleJumps = 1f;
=======
=======
>>>>>>> parent of f0300e55 (#1)


        speed= 5f;
        base.walksmooth=  0f;
        base.jumpSpeed= jumpSpeed = 14f;
        base.attackRange = 2.5f;
        base.attackTime = 0.7f;
        base.attackCooldown = 0.3f;
        base.iFramesTime = 1f;
        base.dashSpeed = 2f;
        base.dashCooldown = 1f;
        base.possibleJumps = 2f;
<<<<<<< HEAD
>>>>>>> parent of f0300e55 (#1)
=======
>>>>>>> parent of f0300e55 (#1)

        MakeDict();

<<<<<<< HEAD
        if (StatHandler.statsDictionary == null) //send the stats for new game
        {
            StatHandler.statsDictionary = statsDictionary;
            PlayerController.statsDictionary = statsDictionary;
        }

    }

=======
        StatHandler.statsDictionary = statsDictionary;
        PlayerController.statsDictionary = statsDictionary;
        Debug.Log(statsDictionary+"player1stats");
    }


>>>>>>> parent of f0300e55 (#1)
}
