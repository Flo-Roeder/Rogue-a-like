using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsParent : MonoBehaviour
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
    public float possibleJumps;


    private void Awake()
    {
        
        StatHandler.statsDictionary = statsDictionary;
        Debug.Log(statsDictionary+"stats parent");
    }


    public void TransferStats() //show the stats in the player picker (start game)
    {
        SetPickDetails.statsDic = statsDictionary;
        
    }

    public virtual void MakeDict() //take the stats and make a dictionary for further work like stathandler etc.
    {
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
    }

}
