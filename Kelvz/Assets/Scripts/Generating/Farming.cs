using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farming : MonoBehaviour
{
    // Start is called before the first frame update
    public int amountOfGoldPerFiveSeconds = 1; 
    private float elapsed;
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        {   
            elapsed += Time.deltaTime;
            if (elapsed >= 5f)
            {
                elapsed = elapsed % 5f;
                player.GetComponent<Player>().addGold(amountOfGoldPerFiveSeconds);

            }
        }
    }
}
