using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlattform : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform[] pointsToHit; 
    public float speed;

   
    [SerializeField] private Transform target;
    [SerializeField]private bool toA;
    private int index=0;


    void Start()
    {
        target = pointsToHit[0];
    }

   
    void Update()
    {

        SetTargetFromArray();
   

    }

    private void FixedUpdate()
    {
       
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            // collision.transform.parent = this.transform;
            collision.transform.SetParent(this.transform);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Enemy"))
        {
           // collision.transform.parent = null;
            collision.transform.SetParent(null);
        }
    }

    private void SetTargetFromArray()
    {
       
        if(transform.position == pointsToHit[index].position)
        {
            if(index+1 <= pointsToHit.Length)
            {
                index++;
            }
            if (index == pointsToHit.Length)
            {
                index = 0;
            }
        }

        target = pointsToHit[index];
    }

}
