using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTopRoom : MonoBehaviour
{
    public Collider2D roomDetectionTop;
    public bool topIsOpen;
    private Vector2 posTop;

    private FillRooms fillRooms;

    private float amount;

    public LayerMask room;


    // Start is called before the first frame update
    void Start()
    {
        fillRooms = this.GetComponent<FillRooms>();
        amount = fillRooms.amountY;
        posTop = new Vector2(transform.localPosition.x, transform.localPosition.y + amount);
    }

    // Update is called once per frame
    void Update()
    {
        if (fillRooms.counter<6)
        {
            fillRooms = this.GetComponent<FillRooms>();
            roomDetectionTop = Physics2D.OverlapCircle(posTop, 2, room);


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

            if (roomDetectionTop == null)
            {

            }


            else if (roomDetectionTop.gameObject.GetComponent<RoomType>().type == 5 || roomDetectionTop.gameObject.GetComponent<RoomType>().type == 7
                || roomDetectionTop.gameObject.GetComponent<RoomType>().type == 8 || roomDetectionTop.gameObject.GetComponent<RoomType>().type == 11
                || roomDetectionTop.gameObject.GetComponent<RoomType>().type == 12 || roomDetectionTop.gameObject.GetComponent<RoomType>().type == 13
                || roomDetectionTop.gameObject.GetComponent<RoomType>().type == 14)
            {
                topIsOpen = true;
                fillRooms.topIsOpen = true;

            }

            else
            {
                topIsOpen = false;
                fillRooms.topIsOpen = false;
            }
        }

       
    }
}
