using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Keybinds : MonoBehaviour
{

    private static Keybinds instance;

    public static Keybinds MyInstance
    {
        get
        {
            if(instance==null)
            {
                instance = FindObjectOfType<Keybinds>();
            }
            return instance;
        }
    }

    public Dictionary<string, KeyCode> Keys;

    public GameObject PopUp;

    private string bindName;
    [SerializeField] private MainMenu MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        Keys = new Dictionary<string, KeyCode>();

        Keybind("LEFT", KeyCode.A);
        Keybind("RIGHT", KeyCode.D);
        Keybind("HIDE", KeyCode.W);
        Keybind("CROUCH", KeyCode.S);
        Keybind("DASH", KeyCode.X);
        Keybind("ATK1", KeyCode.Mouse0);
        Keybind("ATK2", KeyCode.LeftAlt);
        Keybind("JUMP", KeyCode.Space);
    }

    public void Keybind(string keyName, KeyCode keyBind)
    {
        Dictionary<string, KeyCode> currentDictionary = Keys;
        if(!currentDictionary.ContainsKey(keyName))
        {
            currentDictionary.Add(keyName, keyBind);
            MainMenu.KeybindUpdate(keyName,keyBind);
        }
        else if(currentDictionary.ContainsValue(keyBind))
        {
            string myKey = currentDictionary.FirstOrDefault(x => x.Value==keyBind).Key;
            currentDictionary[myKey] = KeyCode.None;
            MainMenu.KeybindUpdate(myKey, KeyCode.None);
        }
        currentDictionary[keyName] = keyBind;
        MainMenu.KeybindUpdate(keyName, keyBind);
        bindName = string.Empty;
    }

    public void KeyBindOnClick(string bindName)
    {
        this.bindName = bindName;
    }

    private void OnGUI()
    {
        if(bindName!=string.Empty)
        {
            Event e = Event.current;

            if(e.isKey||e.isMouse)
            {
                Keybind(bindName, e.keyCode);
                PopUp.SetActive(false);
                
            }
        }
        
    }
}
