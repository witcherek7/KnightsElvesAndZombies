using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButton : MonoBehaviour
{
    private bool deleteMode = false;
    private SpriteRenderer SpriteRenderer;
    public Sprite deleteSprite;
    public Sprite buildSprite;
    private GameObject armoryButtonCopy, towerButtonCopy, farmButtonCopy;
    public GameObject building, confirmButton, armoryButton, farmButton, towerButton;
    private float xPosition, yPosition;
    private bool buildClicked = false, deleteClicked = false;
    private Color spriteOpacityFull = new Color (1f, 1f, 1f, 1f);
    private Color spriteOpacityHalf = new Color (1f, 1f, 1f, 0.5f);
    private bool amILast = true;
    public GameObject EnemySpawn; // co to robi? wyrzuca błąd
    

    void MoveEnemySpawn()
    {
        if(gameObject.transform.position.x+70 < 248)
            EnemySpawn.transform.position = new Vector2(gameObject.transform.position.x+70, gameObject.transform.transform.position.y);
        else
           EnemySpawn.transform.position = new Vector2(248f, gameObject.transform.transform.position.y);
    }

    //private SpriteRenderer sprite;
    //public const string LAYER_NAME = "Buildings";

    // Update is called once per frame
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        xPosition = GetComponent<Transform>().position.x;
        yPosition = GetComponent<Transform>().position.y;
        SpriteRenderer.color = spriteOpacityHalf;
        MoveEnemySpawn();
    }

    void SpawnNewBuildButton()
    {
        Instantiate(GameObject.Find("build_button_template"), new Vector2(xPosition + 3f, yPosition), Quaternion.identity);
    }

    public void ChangeSpriteToDelete()
    {
        if(amILast == true)
        {
            SpawnNewBuildButton();
            amILast = false;
        }
        SpriteRenderer.sprite = deleteSprite;
        deleteMode = true;
        deleteClicked = false;
    }

    public void ChangeSpriteToBuild()
    {
        SpriteRenderer.sprite = buildSprite;
        deleteMode = false;
        buildClicked = false;
    }

    public void DeleteButtons()
    {
        Destroy(armoryButtonCopy);
        Destroy(towerButtonCopy);
        Destroy(farmButtonCopy);

    }

    public void ConfirmAction()
        {
            Destroy(building);
                    foreach (Transform child in gameObject.transform) {
            GameObject.Destroy(child.gameObject);
        }
            ChangeSpriteToBuild();
        }

    void OnMouseDown()
    {
        if (!deleteMode)
        {
            if (!buildClicked)
            {
                Debug.Log("Clicked on button.");
                //GameObject armoryButton = GameObject.Find("Armory_button");
                //GameObject towerButton = GameObject.Find("Tower_button");
                //GameObject farmButton = GameObject.Find("Farm_button");

                armoryButtonCopy = (GameObject)Instantiate(armoryButton, new Vector2(xPosition - 0.75F, yPosition + 0.75F), Quaternion.identity);
                towerButtonCopy = (GameObject)Instantiate(towerButton, new Vector2(xPosition, yPosition + 0.75F), Quaternion.identity);
                farmButtonCopy = (GameObject)Instantiate(farmButton, new Vector2(xPosition + 0.75F, yPosition + 0.75F), Quaternion.identity);
                armoryButtonCopy.transform.parent = transform;
                towerButtonCopy.transform.parent = transform;
                farmButtonCopy.transform.parent = transform;

                buildClicked = true;
            }
            else
            {
                
                DeleteButtons();
                buildClicked = false;

            }
        }
        else
        {
            if(!deleteClicked)
            {
                farmButtonCopy = (GameObject)Instantiate(confirmButton, new Vector2(xPosition, yPosition + 0.75F), Quaternion.identity);
                farmButtonCopy.transform.parent = transform;
                deleteClicked=true;
            }
            else
            {
                Destroy(farmButtonCopy);
                deleteClicked=false;
            }
        }

        

        // {
        //     if (!deleteMode)
        //     {
        //         GameObject building = GameObject.Find("farm");
        //         //sprite = building.GetComponent<SpriteRenderer>();
        //         //sprite.sortingLayerName = LAYER_NAME;
        //         track = (GameObject)Instantiate(building, new Vector2(xPosition, -1.26F), Quaternion.identity);
        //         Debug.Log("Builded");
        //         //Destroy(gameObject);
        //         SpriteRenderer.sprite = deleteSprite;
        //         deleteMode = true;
        //     }
        //     else
        //     {
        //         Destroy(track);
        //         Debug.Log("Deleted building.");
        //         SpriteRenderer.sprite = buildSprite;
        //         deleteMode = false;
        //     }

        // }
    }

    private void OnMouseOver() {
        SpriteRenderer.color = spriteOpacityFull;
    }
    private void OnMouseExit() {
        SpriteRenderer.color = spriteOpacityHalf;
    }
}
