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
    private GameObject[] creatures;
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
    void sendCoordinates(Vector3 flag_coordinates){
        Vector3 coordinates = this.transform.position;
        // find creatures to send info:
        creatures = GameObject.FindGameObjectsWithTag("Troop");
        foreach (GameObject creature in creatures){
            Debug.Log("Sending direction to: "+ flag_coordinates);
            creature.SendMessage("setDirection", flag_coordinates, SendMessageOptions.DontRequireReceiver);
        }
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Destroy(flagCopy);
            Vector2 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            flagCopy = (GameObject)Instantiate(flag, cursor, Quaternion.identity);
            flagCopy.name = "flag";
            flagCopy.transform.parent = transform;
            Vector3 flag_coordinates = flagCopy.transform.position;
            sendCoordinates(flag_coordinates);

        }
    }


}
