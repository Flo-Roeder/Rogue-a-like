using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDetails : MonoBehaviour
{
    // Start is called before the first frame update
    public RawImage image;
    public Text charName;
    public SetPickDetails playerDetails;
    public PlayerStatsParent player;

    public StatHandler statHandler;

    public GameObject[] character;

    public GameObject charPickerArea;


    void Awake()
    {
        for (int i = 0; i < character.Length; i++)
        {
            GameObject instance = Instantiate(character[i], transform.position, Quaternion.identity);
            instance.transform.SetParent(charPickerArea.transform);
            charPickerArea.GetComponent<RectTransform>().sizeDelta = new Vector2(140 * (i + 1), 124);
            charPickerArea.GetComponent<RectTransform>().transform.Translate(new Vector3(70 * (i + 1), 0, 0));
        }
        
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        image.texture = playerDetails.image.texture;
        charName.text = playerDetails.charName.text;
    }

    public void TransferStats()
    {
        StatHandler.statsDictionary = SetPickDetails.statsDic;
        statHandler.ShowStats();
    }

}
