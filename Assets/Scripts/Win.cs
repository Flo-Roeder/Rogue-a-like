using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{

    public bool win;
    public float counter = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (win)
        {
            GetComponent<CanvasGroup>().alpha = 1;

            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
        

    }
}
