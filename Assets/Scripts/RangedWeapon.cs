using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{

    private float timer = 0;
    public float attackTime = 1f;
    public int damage;


    // Update is called once per frame
    void Update()
    {
        if (timer < attackTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
            timer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyController>().EnemyGetsDamaged(damage,false);
        }
    }

}