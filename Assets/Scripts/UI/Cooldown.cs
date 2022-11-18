using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{

    public Image imageDashCooldown;
    public Image imageAttackCooldown;
    public static PlayerController playerController;
    private float dashCooldown;
    private float dashCooldownCounter;
    public float attackCooldown;
    public float attackCooldownCounter;



    // Start is called before the first frame update
    private void OnGUI()
    {

        // imageAttackCooldown = GetComponent<Image>();
        // imageDashCooldown = GetComponent<Image>();
       // playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        imageDashCooldown.fillAmount = 0f;
        dashCooldown = playerController.dashCooldown;
        dashCooldownCounter = dashCooldown;
        imageAttackCooldown.fillAmount = 0f;
        attackCooldown = playerController.attackCooldown;
        attackCooldownCounter = attackCooldown;
        
    }



    // Update is called once per frame
    void Update()
    {
        
        DashCooldown();
        AttackCooldown();
    }

    private void DashCooldown()
    {
        if(playerController.dashed)
        {
            dashCooldownCounter -= Time.fixedDeltaTime;
            imageDashCooldown.fillAmount = dashCooldownCounter/dashCooldown;
        }
        else
        {
            dashCooldownCounter = dashCooldown;
        }
    }

    private void AttackCooldown()
    {
        if(playerController.onCooldown)
        {
            attackCooldownCounter -= Time.deltaTime;
            imageAttackCooldown.fillAmount = (attackCooldownCounter/attackCooldown);
           
        }
        else
        {
            attackCooldownCounter = attackCooldown;
        }
    }

   


}
