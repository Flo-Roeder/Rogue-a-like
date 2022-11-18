using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 10f;
    public float walksmooth;
    public float jumpSpeed = 12f;
    public float attackRange = 10f;
    public float attackTime = 2.5f;
    public float attackCooldown = 0.7f;
    public float iFramesTime = 0.5f;
    private float cooldowntimer = 0.7f;
    public float dashSpeed = 4f;
    public float dashCooldown = 1f;

    

    public float fallMultiplier=3f;
    public float lowJumpMulti=2f;

    public float possibleJumps = 3f;
    public Animator playerAnim;

    [SerializeField] private int actJumps;
    [SerializeField] private int lookDirection = 1; //1=right -1=left
    [SerializeField] private bool isGrounded;
    [SerializeField] private float countdown;

    private Rigidbody2D player;
    public GameObject meleeWeapon;
    public GameObject rangedWeapon;
    public LayerMask groundLayer;


    public bool onCooldown;
    public bool iFrames=false;
    public bool dashed;

    public int maxHealth;
    public int currentHealth;
    public int capHealth;

    public ParticleSystem walkParticles;
    public GameObject checkColliderObject;
    public Collider2D footCollider;

    public static Dictionary<string, float> statsDictionary;

    private Collider2D semiGroundCollider;

    // Start is called before the first frame update

    private void Awake()
    {
        Cooldown.playerController = this;
        GameObject.Find("GameHandler").GetComponent<StatHandler>().playerController = this;
        if (StatHandler.statsDictionary!=null)
        {
            statsDictionary = StatHandler.statsDictionary;
        }
    }

    void Start()
    {

        

        player = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;


        checkColliderObject.transform.position = new Vector2(dashSpeed / Mathf.Abs(transform.localScale.x) - 0.3f, 0.6f / Mathf.Abs(transform.localScale.x));
                
    }

    private void Update()
    {




        //Groundcheck();

        float animSpeed = Mathf.Abs(player.velocity.x);
        playerAnim.SetFloat("speed", animSpeed);

        if(!MainMenu.gameIsPaused)
        {
            TurnPlayer();
            Movement();
            Dash();
            Attack();
        }
        
    }

    private void FixedUpdate()
    {
        if(!MainMenu.gameIsPaused)
        {
            
        }
       


      
        
    }

    private void TurnPlayer()
    {
        if (lookDirection < 0)
        {
            transform.localScale = new(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (lookDirection>0)
        {
            transform.localScale = new(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void Dash()
    {
        float distance=dashSpeed;
        
       // check what checker hits
       //Debug.Log(Physics2D.OverlapCircle(checkColliderObject.transform.position, 0.4f, groundLayer));
        if (Input.GetKeyDown(Keybinds.MyInstance.Keys["DASH"]) && !dashed)
        {
            for (float i = 0f; i <= dashSpeed; i+=0.1f)
            {
                if (Physics2D.OverlapCircle(checkColliderObject.transform.position, 0.5f, groundLayer) != null)
                {
                    distance = dashSpeed - i;
                    checkColliderObject.transform.localPosition = new Vector2(distance, 0.5f);
                }
            }
            
      
            player.position = new Vector2(player.position.x + (distance*lookDirection), player.position.y);
            playerAnim.SetTrigger("dash");
            dashed = true;
            StartCoroutine(DashReset(dashCooldown));
            checkColliderObject.transform.localPosition = new Vector2(dashSpeed/Mathf.Abs(transform.localScale.x)-0.3f, 0.6f / Mathf.Abs(transform.localScale.x));
        }

    }

    private void Movement()
    {
            //crouching   
        if (Input.GetKey(Keybinds.MyInstance.Keys["CROUCH"]) && isGrounded)  //crouch just on ground
        {

            if (Input.GetKeyDown(Keybinds.MyInstance.Keys["JUMP"]))    //falljump through semiground
            {

                Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), semiGroundCollider, true);

               // transform.position = new(transform.position.x,transform.position.y-0.5f);

                StartCoroutine(EnableCollider());
            }
            playerAnim.SetBool("crouch", true);
        }
        else
        {
            playerAnim.SetBool("crouch", false);
        }

        //hideing
        if (Input.GetKey(Keybinds.MyInstance.Keys["HIDE"]) && isGrounded)    //hide just on ground
        {
            playerAnim.SetBool("hide", true);
        }
        else
        {
            playerAnim.SetBool("hide", false);
        }


        //moving
        if (!(playerAnim.GetBool("hide")||playerAnim.GetBool("crouch"))) //just move when not hiding or crouching
        {
            float direction;  //lookdirection for attacks and dashes etc.
            

            if (Input.GetKey(Keybinds.MyInstance.Keys["LEFT"]))
            {
                lookDirection = -1;
    
                    direction = lookDirection;
           
            }
            else if (Input.GetKey(Keybinds.MyInstance.Keys["RIGHT"]))
            {
                lookDirection = 1;
                
                    direction = lookDirection;
        
            }
            else
            {
                direction = 0;
            }
            
            player.velocity = new Vector2(direction * speed, player.velocity.y);
           


            //jumping
            if (Input.GetKeyDown(Keybinds.MyInstance.Keys["JUMP"]) && actJumps < possibleJumps && !Input.GetKey(Keybinds.MyInstance.Keys["CROUCH"]))

            {
               if(!isGrounded)
                {
                    actJumps++;
                }
                
                player.velocity = new Vector2(player.velocity.x, jumpSpeed);
               

            }
                        
            if (player.velocity.y < 0)  //modifier for more satisfiying jumps
            {
                player.velocity += (fallMultiplier - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
            }
            else if (player.velocity.y > 0 && !Input.GetKey(Keybinds.MyInstance.Keys["JUMP"]))
            {
                player.velocity += (lowJumpMulti - 1) * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
            }
          
        }
        else
        {
            player.velocity = new(0, 0);
        }
        


    }

    private IEnumerator DashReset(float dashCounter)
    {
        yield return new WaitForSeconds(dashCounter);
        dashed = false;
    }

    

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.3f);
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), semiGroundCollider, false);
        
    }


    private void Attack()
    {
        
       
        if (Input.GetKeyDown(Keybinds.MyInstance.Keys["ATK1"]) && !playerAnim.GetBool("hide")&&!onCooldown)
        {
           

                GameObject meleeWeaponInstance = Instantiate(meleeWeapon, new Vector3(gameObject.transform.position.x + 0.5f * lookDirection, gameObject.transform.position.y + 0.7f, 0f), Quaternion.identity, gameObject.transform);
                meleeWeaponInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(attackRange * lookDirection, 0);
                onCooldown = true;
            
        }

      



        if (Input.GetKeyDown(Keybinds.MyInstance.Keys["ATK2"]) && !playerAnim.GetBool("hide") && !onCooldown)
        {


            GameObject rangedWeaponInstance = Instantiate(rangedWeapon, new Vector3(gameObject.transform.position.x + 0.5f * lookDirection, gameObject.transform.position.y + 1f, 0f), Quaternion.identity, gameObject.transform);
            rangedWeaponInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(attackRange*10 * lookDirection, 0);
            onCooldown = true;

        }

        if (onCooldown)
        {
            cooldowntimer -= Time.deltaTime;
            if (cooldowntimer < 0)
            {
                onCooldown = false;
                cooldowntimer = attackCooldown;
            }
        }

    }

    /* void Groundcheck()
     {

          Vector2 position = new (transform.position.x,transform.position.y+0.1f);
          Vector2 direction = Vector2.down;
          float distance = 0.1f;


         RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
         Debug.DrawRay(position, direction, color: Color.green, distance);
          if (hit.collider != null)
          {


              isGrounded = true;
             actJumps = 0;
             playerAnim.SetBool("inAir", false);

         }
          else
          {
              isGrounded = false;
             playerAnim.SetBool("inAir",true);

         }


     }
    */

  /*  private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("semiGround"))
        {
           semiGroundCollider= collision.gameObject.GetComponent<CompositeCollider2D>();
        }
    }
  */
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("semiGround"))
        {
            semiGroundCollider = collision.gameObject.GetComponent<CompositeCollider2D>();
        }

        if (collision.gameObject/*.layer== 6*/)
        {
            isGrounded = true;
            actJumps = 0;
            playerAnim.SetBool("inAir", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject/*.layer == 6*/)
        {
            isGrounded = false;
            playerAnim.SetBool("inAir", true);
            actJumps = 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
            actJumps = 0;
            playerAnim.SetBool("inAir", false);
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0 && !iFrames)
        {
            currentHealth += amount;
            playerAnim.SetBool("iFrames", true);
            iFrames = true;
            StartCoroutine(IFrameCounter());
        }

        else if (amount>0)
        {

            if (currentHealth + amount <= maxHealth)
            {
                currentHealth += amount;
                playerAnim.SetTrigger("heal");
            }

            else if(currentHealth==maxHealth)
            {

            }

            else if(currentHealth+amount>maxHealth)
            {
                currentHealth = maxHealth;
                playerAnim.SetTrigger("heal");
            }

            
           
        }
     
    }

    private IEnumerator IFrameCounter()
    {
        yield return new WaitForSeconds(iFramesTime);
        iFrames = false;
        playerAnim.SetBool("iFrames", false);

    }

    public void HealthUp(int amount)
    {
       

        if (maxHealth+amount <= capHealth)
            {
                maxHealth+=amount;
            }
            else
            {
                maxHealth = capHealth;
            }

          

   
    }

   public void SetStatsFromDictionary()
    {

        foreach (var item in statsDictionary)
        {
            GetType().GetField(item.Key.ToString()).SetValue(this, (float)item.Value);
        }
          
        
    }

}
       
    

  

