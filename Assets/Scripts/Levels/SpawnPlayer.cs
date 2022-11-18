using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = StatHandler.player;//GameObject.Find("GameHandler").GetComponent<StatHandler>().player;

        GameObject instance = (GameObject)Instantiate(player, transform.position, Quaternion.identity);
        instance.transform.SetParent(transform);

    }

 
}
