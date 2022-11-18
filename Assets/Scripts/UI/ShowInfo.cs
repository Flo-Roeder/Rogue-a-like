using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfo : MonoBehaviour
{

    public GameObject infoText;

    private TextMesh textMesh;
    private SpriteRenderer childSprite;
    private float a = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        infoText.SetActive(false);
        textMesh = infoText.GetComponent<TextMesh>();
        childSprite = infoText.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, a);
        childSprite.color= new Color(childSprite.color.r, childSprite.color.g, childSprite.color.b, a);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        infoText.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (a < 255)
        {
            a += 1.5f * Time.deltaTime;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        infoText.SetActive(false);
        a = 0;
    }

   
}
