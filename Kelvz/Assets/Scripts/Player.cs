using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int gold = 0;
    public List<GameObject> soldierList = new List<GameObject>();
    public List<GameObject> peasantList = new List<GameObject>();
    private Text goldText;
    public GameObject flag;
    private GameObject flagCopy;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Player_Gold_Text").GetComponent<Text>().text = gold.ToString();
        goldText = GameObject.Find("Player_Gold_Text").GetComponent<Text>();
    }

    public void addGold(int amount)
    {
        gold = gold + amount;
        goldText.text = gold.ToString();
    }

    public void spendGold(int amount)
    {
        gold = gold - amount;
        goldText.text = gold.ToString();
    }

    public void addPeasantToList(GameObject peasant)
    {
        peasantList.Add(peasant);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Destroy(flagCopy);
            Vector2 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            flagCopy = (GameObject)Instantiate(flag, cursor, Quaternion.identity);
            flagCopy.name = "flag";
            flagCopy.transform.parent = transform;
        }
    }


}
