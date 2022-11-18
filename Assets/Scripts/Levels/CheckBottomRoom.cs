using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBottomRoom : MonoBehaviour
{
    public Collider2D roomDetectionBottom;
    public bool bottomIsOpen;
    private Vector2 posBottom;

    private FillRooms fillRooms;

    private float amount;

    public LayerMask room;


    // Start is called before the first frame update
    void Start()
    {
        fillRooms = this.GetComponent<FillRooms>();
        amount = fillRooms.amountY;
        posBottom = new Vector2(transform.localPosition.x, transform.localPosition.y - amount);
    }

    // Update is called once per frame
    void Update()
    {
        if (fillRooms.counter<6)
        {
            fillRooms = this.GetComponent<FillRooms>();
            roomDetectionBottom = Physics2D.OverlapCircle(posBottom, 2, room);



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
            if (roomDetectionBottom == null)
            {

            }

            else if (roomDetectionBottom.gameObject.GetComponent<RoomType>().type == 5 || roomDetectionBottom.gameObject.GetComponent<RoomType>().type == 6
                || roomDetectionBottom.gameObject.GetComponent<RoomType>().type == 9 || roomDetectionBottom.gameObject.GetComponent<RoomType>().type == 10
                || roomDetectionBottom.gameObject.GetComponent<RoomType>().type == 11 || roomDetectionBottom.gameObject.GetComponent<RoomType>().type == 13
                || roomDetectionBottom.gameObject.GetComponent<RoomType>().type == 14 || roomDetectionBottom.gameObject.GetComponent<RoomType>().type == 15)
            {
                bottomIsOpen = true;
                fillRooms.bottomIsOpen = true;
            }

            

            else
            {
                bottomIsOpen = false;
                fillRooms.bottomIsOpen = false;
            }
        }

       
    }
}
