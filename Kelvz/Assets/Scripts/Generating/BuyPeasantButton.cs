using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPeasantButton : MonoBehaviour
{
    // Start is called before the first frame update

    private int peasantNumber = 0;
    public int price;
    private float elapsed;
    private int progressCountInt = 0;
    public GameObject peasant1, peasant2, peasant3, peasant4;
    private SpriteRenderer SpriteRenderer;
    private Color spriteOpacityFull = new Color(1f, 1f, 1f, 1f);
    private Color spriteOpacityHalf = new Color(1f, 1f, 1f, 0.5f);
    public GameObject canvasTextPrefab;
    private GameObject canvasTextCopy;
    private Text text;
    private bool toBuild = false;
    private GameObject tempPeasant, randomPeasant;
    private int peasantRandomizer = 0;
    static Random rnd = new Random();
    private List<GameObject> peasantList = new List<GameObject>();
    void Start()
    {
        peasantList.Add(peasant1);
        peasantList.Add(peasant2);
        peasantList.Add(peasant3);
        peasantList.Add(peasant4);
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SpriteRenderer.color = spriteOpacityHalf;
        canvasTextCopy = (GameObject)Instantiate(canvasTextPrefab, new Vector2(transform.position.x, gameObject.transform.position.y + 0.5f), Quaternion.identity);
        canvasTextCopy.transform.parent = gameObject.transform;
        text = canvasTextCopy.transform.GetChild(0).gameObject.GetComponent<Text>();
        ShowPrice();


    }

    void ShowPrice()
    {
        text.text = price + "$";
    }



    bool CanIBuild()
    {
        if (peasantNumber < 4)
        {
            if (GameObject.Find("Player").GetComponent<Player>().gold >= price)
            {
                Debug.Log("Player gold before build: " + GameObject.Find("Player").GetComponent<Player>().gold);
                GameObject.Find("Player").GetComponent<Player>().spendGold(price);
                return true;
            }
            else
            {
                GameObject.Find("Player_Messages_Text").GetComponent<Messages>().DisplayMessage("Lack of gold.");
                Debug.Log("Player gold: " + GameObject.Find("Player").GetComponent<Player>().gold);
                return false;
            }
        }
        else
        {
            GameObject.Find("Player_Messages_Text").GetComponent<Text>().text = "Max number of peasant per this building.";
            return false;
        }
    }

    void BuildTroop()
    {
        if (toBuild)
        {



            elapsed += Time.deltaTime;
            if (elapsed >= 1f)
            {
                elapsed = elapsed % 1f;

                if (progressCountInt < 100)
                {

                    progressCountInt = progressCountInt + 5;

                    if (progressCountInt > 100)
                        progressCountInt = 100;
                    text.text = progressCountInt + "%";


                }
                else
                {
                    randomPeasant = peasantList[peasantRandomizer];
                    tempPeasant = (GameObject)Instantiate(randomPeasant, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 2), Quaternion.identity);
                    tempPeasant.transform.parent = GameObject.Find("Player").transform;
                    peasantNumber +=1;
                    progressCountInt = 0;
                    GameObject.Find("Player").GetComponent<Player>().addPeasantToList(tempPeasant);
                    Debug.Log(GameObject.Find("Player").GetComponent<Player>().soldierList.Count);
                    toBuild = false;
                    ShowPrice();
                    peasantRandomizer += 1;
                    if (peasantRandomizer == 4)
                    {
                        peasantRandomizer = 0;
                    }

                }

            }

        }

    }

    void OnMouseDown()
    {
        if (toBuild == false)
        {
            if (CanIBuild())
            {
                toBuild = true;
            }
        }
    }

    private void Update()
    {
        BuildTroop();
    }

    private void OnMouseOver()
    {
        SpriteRenderer.color = spriteOpacityFull;
    }
    private void OnMouseExit()
    {
        SpriteRenderer.color = spriteOpacityHalf;
    }
}
