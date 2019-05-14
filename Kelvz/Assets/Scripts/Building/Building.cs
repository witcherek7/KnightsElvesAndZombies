using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public int health = 100;
    private SpriteRenderer spriteRenderer;
    private Transform transform;
    private Color spriteOpacityStart = new Color(1f, 1f, 1f, 0.01f);
    private float progressCount = 0.01f;
    private int progressCountInt = 0;
    //public GameObject progressCanvas;
    private GameObject progressCanvasCopy, progressTextCopy;
    private Text text;
    public bool isBuilding = true;
    public bool initiateBuilding = false;
    private float elapsed;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        transform = gameObject.GetComponent<Transform>();
        spriteRenderer.color = spriteOpacityStart;

        //progressCanvasCopy = (GameObject)Instantiate(progressCanvas, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        //progressCanvasCopy.transform.parent = transform;
        progressCanvasCopy = transform.GetChild(0).gameObject;
        progressTextCopy = progressCanvasCopy.transform.GetChild(0).gameObject;
        text = progressTextCopy.GetComponent<Text>();
        text.text = 0 + "%";

    }


    void BuildMe()
    {
        if (isBuilding && initiateBuilding)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= 1f)
            {
                elapsed = elapsed % 1f;

                if (progressCountInt < 100)
                {
                    progressCount = progressCount + 0.05f;
                    progressCountInt = progressCountInt + 5;
                    spriteRenderer.color = new Color(1f, 1f, 1f, progressCount);
                    if (progressCountInt > 100)
                        progressCountInt = 100;
                    text.text = progressCountInt + "%";
                }
                else
                {
                    isBuilding = false;
                    Destroy(progressCanvasCopy);
                    if (gameObject.name == "armory(Clone)")
                    {
                        gameObject.GetComponent<Armory>().ShowButtons();
                    }
                    if (gameObject.name == "farm(Clone)")
                    {
                        gameObject.GetComponent<Farm>().ShowButton();
                    }
                }

            }
        }
    }

    void DisplayHealth()
    {
        if (health < 100)
        {

        }
    }

    void Update()
    {
        BuildMe();

    }
}
