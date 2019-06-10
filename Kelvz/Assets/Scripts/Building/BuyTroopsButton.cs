using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuyTroopsButton : MonoBehaviour
{ 
    public int price;
    private float elapsed;
    private int progressCountInt = 0;
    public GameObject createMusic;
    private GameObject createMusicCopy;
    public GameObject soldier;
    private SpriteRenderer SpriteRenderer;
    private Color spriteOpacityFull = new Color (1f, 1f, 1f, 1f);
    private Color spriteOpacityHalf = new Color (1f, 1f, 1f, 0.5f);
    public GameObject canvasTextPrefab;
    private GameObject canvasTextCopy;
    private Text text;
    private bool toBuild = false;
    private GameObject tempSoldier;

    void Start() {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SpriteRenderer.color = spriteOpacityHalf;
        canvasTextCopy = (GameObject)Instantiate(canvasTextPrefab, new Vector2(transform.position.x, gameObject.transform.position.y + 0.5f), Quaternion.identity);
        canvasTextCopy.transform.parent = gameObject.transform;
        text = canvasTextCopy.transform.GetChild(0).gameObject.GetComponent<Text>();    
        ShowPrice();
        createMusicCopy = (GameObject) Instantiate(createMusic, new Vector2(gameObject.transform.position.x,transform.position.y), Quaternion.identity);



    }

    void ShowPrice()
    {
        text.text = price + "$";
    }



    bool CanIBuild()
    {
        if(GameObject.Find("Player").GetComponent<Player>().gold>=price)
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

       void BuildTroop()
    {
        if(toBuild){

     

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
                    tempSoldier = (GameObject)Instantiate(soldier,new Vector2(gameObject.transform.position.x,gameObject.transform.position.y-1),Quaternion.identity);
                    tempSoldier.transform.parent =  GameObject.Find("Player").transform;
                    progressCountInt = 0;
                    GameObject.Find("Player").GetComponent<Player>().soldierList.Add(tempSoldier);
                    Debug.Log(GameObject.Find("Player").GetComponent<Player>().soldierList.Count);
                    toBuild = false;
                   ShowPrice();
                    createMusicCopy.GetComponent<AudioSource>().Play(0);
                    
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

    private void Update() {
        BuildTroop();
    }

    private void OnMouseOver() {
        SpriteRenderer.color = spriteOpacityFull;
    }
    private void OnMouseExit() {
        SpriteRenderer.color = spriteOpacityHalf;
    }
    private void OnDestroy() {
        Destroy(createMusicCopy);
    }
}
