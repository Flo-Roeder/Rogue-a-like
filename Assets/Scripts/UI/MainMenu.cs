using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public static bool gameIsPaused;

   [SerializeField] private GameObject[] keybindButtons;

    private void Awake()
    {
        keybindButtons = GameObject.FindGameObjectsWithTag("Keybind");
       
    }

   
    private void Update()
    {
        PauseGame();
    }
    // Start is called before the first frame update
    public void PlayGame()
    {
        if (StatHandler.player!=null)
        {
            SceneManager.LoadScene(1);
        }
        
    }

    public void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        
    }

    public void Resume()
    {
        mainMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            if (gameIsPaused)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1;
            }
            mainMenu.SetActive(gameIsPaused);
        }
      
    }

    public void KeybindUpdate(string key, KeyCode code)
    {
        TextMeshProUGUI tmp = Array.Find(keybindButtons, x => x.name == key).GetComponentInChildren<TextMeshProUGUI>();
        tmp.text = code.ToString();
        
    }
   
}
