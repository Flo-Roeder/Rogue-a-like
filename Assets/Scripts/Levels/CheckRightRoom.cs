using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRightRoom : MonoBehaviour
{
    public Collider2D roomDetectionRight;
    public bool rightIsOpen;
    private Vector2 posRight;

    private FillRooms fillRooms;

    public float amount;

    public LayerMask room;


    // Start is called before the first frame update
    void Start()
    {
        fillRooms = this.GetComponent<FillRooms>();
        amount = fillRooms.amountX;
        posRight = new Vector2( transform.localPosition.x + amount, transform.localPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (fillRooms.counter<6)
        {
            fillRooms = this.GetComponent<FillRooms>();
            roomDetectionRight = Physics2D.OverlapCircle(posRight, 2, room);

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

            if (roomDetectionRight == null)
            {

            }


            else if (roomDetectionRight.gameObject.GetComponent<RoomType>().type == 4 || roomDetectionRight.gameObject.GetComponent<RoomType>().type == 8
                || roomDetectionRight.gameObject.GetComponent<RoomType>().type == 9 || roomDetectionRight.gameObject.GetComponent<RoomType>().type == 10
                || roomDetectionRight.gameObject.GetComponent<RoomType>().type == 12 || roomDetectionRight.gameObject.GetComponent<RoomType>().type == 13
                || roomDetectionRight.gameObject.GetComponent<RoomType>().type == 14 || roomDetectionRight.gameObject.GetComponent<RoomType>().type == 15)
            {
                rightIsOpen = true;
                fillRooms.rightIsOpen = true;

            }
            else
            {
                rightIsOpen = false;
                fillRooms.rightIsOpen = false;
            }
        }

        
    }
}