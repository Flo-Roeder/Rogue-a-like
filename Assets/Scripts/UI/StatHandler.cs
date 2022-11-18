using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;





public class StatHandler : MonoBehaviour
{
    public static Dictionary<string, float> statsDictionary;
    public TextMeshProUGUI text;

    private GameObject Keys;
    private GameObject Values;
   // private GameObject StatsParent; //not needed?

    public PlayerController playerController;

    public ShowDetails showDetails;
<<<<<<< HEAD
<<<<<<< HEAD

    public static GameObject player;
    public GameObject defaultPlayer;

    private void Awake()
    {
        //set default player for testing scenes
        if (player==null)
        {
            player = defaultPlayer;
        }

        //destroy test-gamemanager when playing over the scenes
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnGUI()
    {
        //clear the stats UI at scene switch
        this.Keys = null;
        this.Values = null;
       // this.StatsParent = null; //not needed?

        DontDestroyOnLoad(this.gameObject);

        //set stats UI at scene start
        Keys = GameObject.Find("Keys");
        Values = GameObject.Find("Values");
       // StatsParent = GameObject.Find("Stats"); //not needed?
        if (SceneManager.GetActiveScene().buildIndex!=0)
        {
            ShowStats();
        }
        
    }

    void Start()
    {
       



        if (SceneManager.GetActiveScene().buildIndex == 0) //no player in main menu
        {
            playerController = null;
        }
        else //get player and set the stats as "saved"
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            PlayerController.statsDictionary = statsDictionary;
            playerController.SetStatsFromDictionary();
        }



=======
=======
>>>>>>> parent of f0300e55 (#1)
    void Start()
    {
        //CharPicker charPicker = GameObject.Find("CharPicker").GetComponent<CharPicker>();


    /*    if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            playerController = null;
        }
        else
    */
        {
            
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();


          //  PlayerController.statsDictionary = statsDictionary;

            ShowStats();
            playerController.SetStatsFromDictionary();
        }
<<<<<<< HEAD
>>>>>>> parent of f0300e55 (#1)
=======
>>>>>>> parent of f0300e55 (#1)
    }

    private void Update()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        //update player stats //really necessary?
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            playerController.SetStatsFromDictionary();
        }

=======
        playerController.SetStatsFromDictionary();
>>>>>>> parent of f0300e55 (#1)
=======
        playerController.SetStatsFromDictionary();
>>>>>>> parent of f0300e55 (#1)
    }


    public void UpdateStats(string statName, float statValue, string operater)
    {
        float newValue = CalculateStatValue(statName, statValue, operater);

        statsDictionary[statName] = newValue;

        ShowStatsUpdate(statName, newValue);

        playerController.SetStatsFromDictionary(); //gibt die stats an den playercontroller
        statsDictionary = PlayerController.statsDictionary;
    }

    public void ShowStats()
    {
<<<<<<< HEAD
<<<<<<< HEAD

        foreach (Transform child in Keys.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        foreach (Transform child in Values.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            statsDictionary = PlayerController.statsDictionary;
        }

=======
        statsDictionary = PlayerController.statsDictionary;
>>>>>>> parent of f0300e55 (#1)
=======
        statsDictionary = PlayerController.statsDictionary;
>>>>>>> parent of f0300e55 (#1)

        foreach (var statName in statsDictionary)
        {

            TextMeshProUGUI textShow = GameObject.Instantiate(text);
            textShow.transform.SetParent(Keys.transform);
            textShow.text = statName.Key.ToString();
            textShow.name = statName.Key.ToString();
            TextMeshProUGUI textShow2 = GameObject.Instantiate(text);
            textShow2.transform.SetParent(Values.transform);
            textShow2.text = statName.Value.ToString();
            textShow2.name = statName.Key.ToString() + "V";
        }
    }

    public void ShowStatsUpdate(string statName, float statValue)
    {
        GameObject.Find(statName + "V").GetComponent<TextMeshProUGUI>().text = statValue.ToString();
    }

    private float CalculateStatValue(string statName, float statVlaue, string operater)
    {
        float oldValue = statsDictionary[statName];
        if (operater == "+")
        {
            return oldValue + statVlaue;
        }
        if (operater == "-")
        {
            return oldValue - statVlaue;
        }
        if (operater == "/")
        {
            return oldValue / statVlaue;
        }
        if (operater == "*")
        {
            return oldValue * statVlaue;
        }
        return 0;
    }

}


