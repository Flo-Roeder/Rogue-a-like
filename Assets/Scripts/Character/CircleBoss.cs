using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CircleBoss : MonoBehaviour
{

    public int health;

    public Slider healthBar;

    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue =  health;
        healthBar.value = health;

        winText = GameObject.Find("Win");
    }

    // Update is called once per frame
    void Update()
    {
        if (health<=0)
        {
            Die();
        }
    }

    public void GetDamage(int damage)
    {
        health -= damage;
        healthBar.value = health;
    }

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log("win");
        winText.GetComponent<Win>().win = true;




    }

}
