using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Rigidbody2D enemyRb;

    public float moveSpeed;
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
    public Transform groundcheckPos;
    public Collider2D bodyCollider;

    public GameObject shieldObject;
    public int health;
    public int shield;
    public Gradient healthGradient;
    
    public TextMesh healthText;

    private bool mustTurn;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
       
        healthText = healthText.GetComponent<TextMesh>();

        if(shield>0)
        {
            shieldObject.SetActive(true);
        }
        else
        {
            Destroy(shieldObject);
        }
    }

    private void Update()
    {
        SetHealth();
        SetColorByHealth(health);
        SetShieldColor(shield);
    }

    private void FixedUpdate()
    {
        MoveEnemy();
        mustTurn = !Physics2D.OverlapCircle(groundcheckPos.position, 0.3f,groundLayer);
       // Debug.Log(Physics2D.OverlapCircle(groundcheckPos.position, 0.1f,groundLayer));
    }


    void MoveEnemy()
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer) || bodyCollider.IsTouchingLayers(enemyLayer))
        {
            FlipBody();
        }

        enemyRb.velocity=new Vector2((moveSpeed* Time.deltaTime),enemyRb.velocity.y); 
        
    }

    void FlipBody()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        healthText.transform.localScale = new Vector2(healthText.transform.localScale.x * -1, healthText.transform.localScale.y);
        moveSpeed *= -1;
    }

    void SetHealth()
    {
        healthText.text=health.ToString();
    }

    public void EnemyGetsDamaged(int damgeAmount,bool shieldbreak)
    {
        if (shield > 0 && shieldbreak)
        {
            
            shield--;

            if(shield<=0)
            {
                shieldObject.SetActive(false);
            }
        }

        else if(shield<=0)
        {
            health-=damgeAmount;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

   

    Color SetColorByHealth (float healthValue)
    {
       // Debug.Log(healthGradient.Evaluate(healthValue));
        return gameObject.GetComponent<SpriteRenderer>().color = healthGradient.Evaluate(healthValue/100);
        
    }

    Color SetShieldColor(float shieldValue)
    {
        
        return shieldObject.GetComponent<SpriteRenderer>().color = healthGradient.Evaluate(shieldValue / 100);

    }

}
