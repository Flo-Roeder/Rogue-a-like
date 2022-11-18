using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillRooms : MonoBehaviour
{
    public LayerMask room;
    public LevelGeneration levelGeneration;
    public float amountX;
    public float amountY;

    public int rand;

    public Collider2D roomDetection;
 

    public bool topIsOpen;
    public bool bottomIsOpen;
    public bool leftIsOpen;
    public bool rightIsOpen;

    private bool t; //also indexes of rooms in levelgenerator
    private bool r;
    private bool b;
    private bool l;
    private bool lr;
    private bool tb;
    private bool lt;
    private bool tr;
    private bool rb;
    private bool bl;
    private bool ltr;
    private bool trb;
    private bool rbl;
    private bool blt;
    private bool ltrb;

    public int counter;


    public Vector2 detectionPositionTop;
    public Vector2 detectionPositionBottom;

    private float timeBTWrooms;
    public float starttimeBTWrooms = 0.25f;


    private void Awake()
    {
        amountX = levelGeneration.moveAmountX;
        amountY = levelGeneration.moveAmountY;

        
    }

    private void Start()
    {





        counter = 0;

    }
    void FixedUpdate()
    {
        

        
        if (levelGeneration.stopGenerate == true)
        {
            if (counter<5)
            {
                counter++;
                roomDetection = Physics2D.OverlapCircle(transform.localPosition, 1, room);

                SetRoomBools();

                if (timeBTWrooms <= 0)
                {
                    if (roomDetection == null)
                    {
                        FillEdgeRooms();
                        counter++;
                    }
                    
                    timeBTWrooms = starttimeBTWrooms;
                }
                else
                {
                    timeBTWrooms -= Time.deltaTime;
                }
            }

           if (counter==5)
            {
                if (roomDetection==null)
                {
                    Destroy(gameObject);
                    
                }
                counter++;
            }

          

        }

        
         
    }

    void SetRoomBools()
    {
        if (topIsOpen&&!rightIsOpen&&!bottomIsOpen&&!leftIsOpen)
        {
            t = true;
        }
        else if (!topIsOpen && rightIsOpen && !bottomIsOpen && !leftIsOpen)
        {
            r = true;
        }
        else if (!topIsOpen && !rightIsOpen && bottomIsOpen && !leftIsOpen)
        {
            b = true;
        }
        else if (!topIsOpen && !rightIsOpen && !bottomIsOpen && leftIsOpen)
        {
            l = true;
        }
        else if (topIsOpen && !rightIsOpen && bottomIsOpen && !leftIsOpen)
        {
            tb = true;
        }
        else if (!topIsOpen && rightIsOpen && !bottomIsOpen && leftIsOpen)
        {
            lr = true;
        }
        else if (topIsOpen && rightIsOpen && !bottomIsOpen && !leftIsOpen)
        {
            tr = true;
        }
        else if (!topIsOpen && rightIsOpen && bottomIsOpen && !leftIsOpen)
        {
            rb = true;
        }
        else if (!topIsOpen && !rightIsOpen && bottomIsOpen && leftIsOpen)
        {
            bl = true;
        }
        else if (topIsOpen && !rightIsOpen && !bottomIsOpen && leftIsOpen)
        {
            lt = true;
        }
        else if (topIsOpen && rightIsOpen && !bottomIsOpen && leftIsOpen)
        {
            ltr = true;
        }
        else if (topIsOpen && rightIsOpen && bottomIsOpen && !leftIsOpen)
        {
            trb = true;
        }
        else if (!topIsOpen && rightIsOpen && bottomIsOpen && leftIsOpen)
        {
            rbl = true;
        }
        else if (topIsOpen && !rightIsOpen && bottomIsOpen && leftIsOpen)
        {
            blt = true;
        }
        else if (topIsOpen && rightIsOpen && bottomIsOpen && leftIsOpen)
        {
            ltrb = true;
        }
    }

    void FillEdgeRooms()
    {
            if (ltrb)
            {
                Instantiate(levelGeneration.rooms[14], transform.localPosition, Quaternion.identity);
            }


            else if (blt)
            {
                Instantiate(levelGeneration.rooms[13], transform.localPosition, Quaternion.identity);
            }
            else if(rbl)
            {
                Instantiate(levelGeneration.rooms[12], transform.localPosition, Quaternion.identity);
            }
            else if (trb)
            {
                Instantiate(levelGeneration.rooms[11], transform.localPosition, Quaternion.identity);
            }
            else if (ltr)
            {
                Instantiate(levelGeneration.rooms[10], transform.localPosition, Quaternion.identity);
            }


            else if (lt)
            {
                Instantiate(levelGeneration.rooms[9], transform.localPosition, Quaternion.identity);
            }
            else if (bl)
            {
                Instantiate(levelGeneration.rooms[8], transform.localPosition, Quaternion.identity);
            }
            else if (rb)
            {
                Instantiate(levelGeneration.rooms[7], transform.localPosition, Quaternion.identity);
            }
            else if (tr)
            {
                Instantiate(levelGeneration.rooms[6], transform.localPosition, Quaternion.identity);
            }
            else if (tb)
            {
                Instantiate(levelGeneration.rooms[5], transform.localPosition, Quaternion.identity);
            }
            else if (lr)
            {
                Instantiate(levelGeneration.rooms[4], transform.localPosition, Quaternion.identity);
            }
            /*private bool t;     0
   private bool r;     1
   private bool b;     2
   private bool l;     3
   private bool lr;    4
   private bool tb;    5
   private bool lt;    6
   private bool tr;    7
   private bool rb;    8
   private bool bl;    9
   private bool ltr;   10
   private bool trb;   11
   private bool rbl;   12
   private bool blt;   13
   private bool ltrb;  14
 */

            else if (l)
            {
                Instantiate(levelGeneration.rooms[3], transform.localPosition, Quaternion.identity);
            }
            else if (b)
            {
                Instantiate(levelGeneration.rooms[2], transform.localPosition, Quaternion.identity);
            }
            else if (r)
            {
                Instantiate(levelGeneration.rooms[1], transform.localPosition, Quaternion.identity);
            }
            else if (t)
            {
                Instantiate(levelGeneration.rooms[0], transform.localPosition, Quaternion.identity);
            }
            //Destroy(gameObject);

    }


}

  
