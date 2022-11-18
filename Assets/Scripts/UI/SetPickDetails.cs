using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPickDetails : MonoBehaviour
{
    // Start is called before the first frame update
    public RawImage image;
    public Text charName;
    public static Dictionary<string, float> statsDic;
    public Button btn;

    void Start()
    {
<<<<<<< HEAD
<<<<<<< HEAD
  
        statsDic = PlayerStatsParent.statsDictionary;
        if (GameObject.Find("Charakter Detail"))
        {
            showDetails = GameObject.Find("Charakter Detail").GetComponent<ShowDetails>();
            btn = this.GetComponent<Button>();
            btn.onClick.AddListener(showDetails.TransferStats);
        }
        
        


    }

 

    public void SendData()
    {
        showDetails.playerDetails = this;
//        StatHandler statHandler = GameObject.Find("GameHandler").GetComponent<StatHandler>();
        StatHandler.player = player;
    }
    
=======
=======
>>>>>>> parent of f0300e55 (#1)
      
    }

    // Update is called once per frame
    void Update()
    {

    }

<<<<<<< HEAD
>>>>>>> parent of f0300e55 (#1)
=======
>>>>>>> parent of f0300e55 (#1)
    

}
