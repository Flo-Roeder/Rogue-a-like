using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

   // public GameObject heartContainer;
    public Image emptyHeartImage;
    public Image filledHeartImage;

    [SerializeField] private int fullHearts;
    [SerializeField] private int emptyHearts;

    private float offset;
    private int heartCount;


    private void Start()
    {
        offset = 20f;
    }

    void Update()
    {
        GetHealth();
        ViewHearts();
    }

    void GetHealth()
    {
        heartCount = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().maxHealth;
        fullHearts = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().currentHealth;
        emptyHearts = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().maxHealth - GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().currentHealth;
    }

    public void ViewHearts()
    {
        foreach (Transform child in gameObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
      
            for (int i = 0; i < heartCount; i++)
        {

            if(fullHearts>i)
            {
                Image heart = GameObject.Instantiate(filledHeartImage, gameObject.transform);
                heart.transform.position += new Vector3(offset * i, 0, 0);
                heart.gameObject.SetActive(true);
            }
           
            if(fullHearts<=i && emptyHearts+fullHearts>=i)
            {
                Image heart = GameObject.Instantiate(emptyHeartImage, gameObject.transform);
                heart.transform.position += new Vector3(offset * i, 0, 0);
                heart.gameObject.SetActive(true);
            }


        }
     
        
       
    }

}
