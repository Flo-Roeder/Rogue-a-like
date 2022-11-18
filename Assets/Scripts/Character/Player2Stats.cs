using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Stats : MonoBehaviour
{
    public static Dictionary<string, float> statsDictionary;
  


    public float speed;
    public float walksmooth;
    public float jumpSpeed;
    public float attackRange;
    public float attackTime;
    public float attackCooldown;
    public float iFramesTime;
    public float dashSpeed;
    public float dashCooldown;
    public int possibleJumps;


    void Awake()
    {
        //set stats for dictionary
        speed = 5f;
        walksmooth = 1f;
        jumpSpeed = 20f;
        attackRange = 3f;
        attackTime = 3f;
        attackCooldown = 1f;
        iFramesTime = 1f;
        dashSpeed = 2f;
        dashCooldown = 0.5f;
        possibleJumps = 2;

        statsDictionary = new Dictionary<string, float>
        {
            { "speed", speed },
            { "jumpSpeed", jumpSpeed },
            { "attackRange", attackRange },
            { "attackTime", attackTime },
            { "attackCooldown", attackCooldown },
            { "iFramesTime", iFramesTime },
            { "dashSpeed", dashSpeed },
            { "dashCooldown", dashCooldown },
            { "possibleJumps", possibleJumps }
        };


<<<<<<< HEAD
<<<<<<< HEAD
        if (StatHandler.statsDictionary == null) //send the stats for new game
        {
            StatHandler.statsDictionary = statsDictionary;
            PlayerController.statsDictionary = statsDictionary;
        }




=======
=======
>>>>>>> parent of f0300e55 (#1)

        StatHandler.statsDictionary = statsDictionary;
       
        
       
<<<<<<< HEAD
>>>>>>> parent of f0300e55 (#1)
=======
>>>>>>> parent of f0300e55 (#1)
    }

    public void TransferStats()
    {
        SetPickDetails.statsDic = statsDictionary;
    }

}
