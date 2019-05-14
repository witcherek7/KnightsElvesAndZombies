using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int gold = 0;
    public List<GameObject> soldierList = new List<GameObject>();
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player_Gold_Text").GetComponent<Text>().text = gold.ToString();
    }

    public void addGold(int amount)
    {
        gold = gold + amount;
        text.text = gold.ToString();
    }

    public void spendGold(int amount)
    {
        gold = gold - amount;
        text.text = gold.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
