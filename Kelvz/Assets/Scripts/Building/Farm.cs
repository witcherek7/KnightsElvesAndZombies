using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    private float elapsed;
    public int amountOfGoldPerFiveSeconds = 1; 
    private GameObject player;
    public GameObject peasantButton;
    private GameObject peasantButtonCopy;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!gameObject.GetComponent<Building>().isBuilding)
        {   
            elapsed += Time.deltaTime;
            if (elapsed >= 5f)
            {
                elapsed = elapsed % 5f;
                player.GetComponent<Player>().addGold(amountOfGoldPerFiveSeconds);

            }
        }
    }

    public void ShowButton()
    {
        peasantButtonCopy = (GameObject)Instantiate(peasantButton, new Vector2(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y + 1.2f), Quaternion.identity);
        peasantButtonCopy.transform.parent = gameObject.transform;


    }
}
