using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGeneration : MonoBehaviour
{

    public Transform[] startingPos;
    public GameObject[] rooms; //all 15 roomtypes

    private int direction;
    public float moveAmountX;
    public float moveAmountY;

    private float timeBTWrooms;
    public float starttimeBTWrooms=0.25f;

    public float minX;
    public float maxX;
    public float maxY;

    public bool stopGenerate;

    public LayerMask room;

    private int upCounter;
    private int roomSpawnCounter;
    public int roomsToSpawn;

    public GameObject endStone;

    // Start is called before the first frame update
    void Awake()
    {
        roomSpawnCounter = 0;
        upCounter = 0;

        

            int randStartPos = Random.Range(1, startingPos.Length - 1);
            transform.position = startingPos[randStartPos].position;
            Instantiate(rooms[15], transform.position, Quaternion.identity);
        
       

        direction = Random.Range(1, 6);
    }

    private void Update()
    {
        if (roomSpawnCounter < roomsToSpawn)
        {

            if (timeBTWrooms <= 0 && !stopGenerate)
            {
                roomSpawnCounter++;
                Move();
                timeBTWrooms = starttimeBTWrooms;
            }
            else
            {
                timeBTWrooms -= Time.deltaTime;
            }
        }
        else if(roomSpawnCounter==roomsToSpawn)
        {
            Instantiate(endStone,new Vector3( transform.position.x,transform.position.y,-1),Quaternion.identity);
            stopGenerate = true;
            roomSpawnCounter++;
        }
       
    }


    private void Move()
    {
        
        if (direction==1||direction==2) //move right
        {
            

            if (transform.position.x<maxX)
            {
                upCounter = 0;


                Vector2 newPos = new(transform.position.x + moveAmountX, transform.position.y);
                transform.position = newPos;

                

                int rand = Random.Range(0, 4);
                if (rand==0)
                {
                    rand = 4;
                }
                if (rand == 1)
                {
                    rand = 10;
                }
                if (rand == 2)
                {
                    rand = 12;
                }
                if (rand == 3)
                {
                    rand = 14;
                }
                Instantiate(rooms[rand], transform.position, Quaternion.identity);


                direction = Random.Range(1, 6);
                if(direction==3)
                {
                    direction = 2;
                }
                else if (direction==4)
                {
                    direction = 2;
                }
            }
            else
            {
                direction = 5;
            }
            
        }
        else if (direction == 3 || direction == 4) //move left
        {
            

            if (transform.position.x>minX)
            {
                upCounter = 0;
                Vector2 newPos = new(transform.position.x - moveAmountX, transform.position.y);
                transform.position = newPos;


                int rand = Random.Range(0, 4);
                if (rand == 0)
                {
                    rand = 4;
                }
                if (rand == 1)
                {
                    rand = 10;
                }
                if (rand == 2)
                {
                    rand = 12;
                }
                if (rand == 3)
                {
                    rand = 14;
                }
                
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 6);
                
            }
            else
            {
                direction = 5;
            }
           
        }
        else if (direction == 5) //move up
        {
            upCounter++;

            if (transform.position.y<maxY)
            {


                Collider2D roomDetection = Physics2D.OverlapCircle(transform.localPosition, 1, room);
                if (roomDetection.GetComponent<RoomType>().type == 15||roomDetection.GetComponent<RoomType>().type==14
                    || roomDetection.GetComponent<RoomType>().type == 13|| roomDetection.GetComponent<RoomType>().type == 11)
                {

                    Vector2 newPos = new(transform.position.x, transform.position.y + moveAmountY);
                    transform.position = newPos;


                    int rand = Random.Range(0, 1);
                    if (rand == 0)
                    {
                        rand = 12;
                    }
                    if (rand == 1)
                    {
                        rand = 14;
                    }



                    Instantiate(rooms[rand], transform.position, Quaternion.identity);

                    direction = Random.Range(1, 6);
                }
                else
                {
                    if (upCounter > 1)
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                      
                        int topToprand = Random.Range(0, 4);
                        if (topToprand == 0)
                        {
                            topToprand = 5;
                        }
                        if (topToprand == 1)
                        {
                            topToprand = 11;
                        }
                        if (topToprand == 2)
                        {
                            topToprand = 13;
                        }
                        if (topToprand == 3)
                        {
                            topToprand = 14;
                        }
                        Instantiate(rooms[topToprand], transform.position, Quaternion.identity);
                    }
                    else
                    {
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
                        roomDetection.GetComponent<RoomType>().RoomDestruction();

                        int randTop = Random.Range(0, 1);
                        if (randTop == 0)
                        {
                            randTop = 10;
                        }
                        if (randTop == 1)
                        {
                            randTop = 14;
                        }

                        Instantiate(rooms[randTop], transform.position, Quaternion.identity);
                    }
                }
                
            }
            else
            {
                //stop generate
                transform.position = new(0, 0);
                stopGenerate = true;
            }
        }

        
    }

   
}
