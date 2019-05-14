using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondaryBuildButtons : MonoBehaviour
{
    public int price;
    private GameObject parent, buildingCopy;
    public GameObject building;
    private float yPosition;
    private SpriteRenderer SpriteRenderer;
    private Color spriteOpacityFull = new Color(1f, 1f, 1f, 1f);
    private Color spriteOpacityHalf = new Color(1f, 1f, 1f, 0.5f);
    public Text text;

    void Start()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SpriteRenderer.color = spriteOpacityHalf;
        text.text = price + "$";

    }

    bool CanIBuild()
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

    void OnMouseDown()
    {
        if (CanIBuild())
        {
            Debug.Log("Build  button clicked.");
            parent = transform.parent.gameObject;
            parent.GetComponent<BuildButton>().DeleteButtons();
            parent.GetComponent<BuildButton>().ChangeSpriteToDelete();
            
            yPosition = parent.transform.position.y-1.2f;
            Debug.Log(yPosition);

            if (building.name == "farm")
            {
                buildingCopy = (GameObject)Instantiate(building, new Vector2(parent.transform.position.x, yPosition-0.5f), Quaternion.identity);
            }
            else
            {
                buildingCopy = (GameObject)Instantiate(building, new Vector2(parent.transform.position.x, yPosition), Quaternion.identity);
            }
            Debug.Log("Building built.");
            buildingCopy.transform.parent = parent.transform;
            buildingCopy.GetComponent<Building>().initiateBuilding = true;

            parent.GetComponent<BuildButton>().building = buildingCopy;
        }
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