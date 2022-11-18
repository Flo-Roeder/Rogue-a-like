using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealPotion : MonoBehaviour

{
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().Heal(1);
            Destroy(gameObject);
        }
            
      
    }

   
}
