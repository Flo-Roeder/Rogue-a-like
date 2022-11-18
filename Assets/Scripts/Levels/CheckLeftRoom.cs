using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLeftRoom : MonoBehaviour
{
    public Collider2D roomDetectionLeft;
    public bool leftIsOpen;
    private Vector2 posLeft;

    private FillRooms fillRooms;

    private float amount;

    public LayerMask room;


    // Start is called before the first frame update
    void Start()
    {
        fillRooms = this.GetComponent<FillRooms>();
        amount = fillRooms.amountX;
        posLeft = new Vector2(transform.localPosition.x - amount, transform.localPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (fillRooms.counter<6)
        {
            fillRooms = this.GetComponent<FillRooms>();
            roomDetectionLeft = Physics2D.OverlapCircle(posLeft, 2, room);

            /*private bool t;     0
              private bool r;     1
              private bool b;     2
              private bool l;     3
              private bool lr;    4
              private bool tb;    5
              private bool lt;    9 
              private bool tr;    6 
              private bool rb;    7 
              private bool lb;    8 
              private bool ltr;   10
              private bool trb;   11
              private bool rbl;   12
              private bool blt;   13
              private bool ltrb;  14
            */

            if (roomDetectionLeft == null)
            {

            }


            else if (roomDetectionLeft.gameObject.GetComponent<RoomType>().type == 4 || roomDetectionLeft.gameObject.GetComponent<RoomType>().type == 7
                || roomDetectionLeft.gameObject.GetComponent<RoomType>().type == 6 || roomDetectionLeft.gameObject.GetComponent<RoomType>().type == 10
                || roomDetectionLeft.gameObject.GetComponent<RoomType>().type == 11 || roomDetectionLeft.gameObject.GetComponent<RoomType>().type == 12
                || roomDetectionLeft.gameObject.GetComponent<RoomType>().type == 14 || roomDetectionLeft.gameObject.GetComponent<RoomType>().type == 15)
            {
                leftIsOpen = true;
                fillRooms.leftIsOpen = true;
            }

            else
            {
                leftIsOpen = false;
                fillRooms.leftIsOpen = false;
            }
        }
       
    }
}