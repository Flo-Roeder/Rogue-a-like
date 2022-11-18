using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable IDE1006 // Benennungsstile
public class healthUpPotion : MonoBehaviour
#pragma warning restore IDE1006 // Benennungsstile
{

    private StatHandler statHandler;

    private void Start()
    {
        statHandler = GameObject.Find("GameHandler").GetComponent<StatHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().HealthUp(1);

            //for augments or something
            statHandler.UpdateStats("speed", 3f,"*");
            statHandler.UpdateStats("jumpSpeed", 5f, "+");
            statHandler.UpdateStats("attackRange", 20, "*");
            statHandler.UpdateStats("attackTime", 2f, "-");

            
            Destroy(gameObject);
            
        }
    }

}
